using Appusion.Core.BaseModels;
using Appusion.Core.Common.Entities.User;
using Appusion.Core.Common.Interface.Repositories;
using Appusion.Core.Common.Interface.Services;
using Appusion.Core.Common.ParameterModels.Email;
using Appusion.Core.Common.ParameterModels.User;
using Appusion.Core.Common.RequestModels.User;
using Appusion.Core.Common.ResponseModels;
using Appusion.Core.Common.ResponseModels.General;
using Appusion.Core.Common.ResponseModels.User;
using Appusion.Core.Common.Utility;
using Appusion.Core.ExceptionBase;
using Appusion.Core.Services.Base;
using AutoMapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Services.User
{
    public class UserComponent : ComponentBase
    {
        private IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;
        private readonly IUserEntityRepository _userEntityRepository;
        private readonly IMailService _mailService;
        private readonly IUserActivationEntityRepository _userActivationRepository;
        private readonly IOptions<UserParameter> _userParameters;
        private readonly IUserOtpEntityRepository _userOtpRepository;
        private readonly IUserSessionRepository _userSessionRepository;
        public UserComponent(IJwtUtils jwtUtils,
            IMapper mapper,
            IUserEntityRepository userEntityRepository,
            IMailService mailService,
            IUserActivationEntityRepository userActivationRepository,
            IOptions<UserParameter> userParameters,
            IUserOtpEntityRepository userOtpRepository,
            IUserSessionRepository userSessionRepository
            )
        {
            _jwtUtils = jwtUtils;
            _mapper = mapper;
            _userEntityRepository = userEntityRepository;
            _mailService = mailService;
            _userActivationRepository = userActivationRepository;
            _userParameters = userParameters;
            _userOtpRepository = userOtpRepository;
            _userSessionRepository = userSessionRepository;
        }

        public async Task<UserAuthenticateResponsePackage> Authenticate(UserAuthenticateRequestPackage authenticateRequest)
        {
            var userEntity = await _userEntityRepository.GetUserEntity(authenticateRequest.EmailAddress);
            if (userEntity == null || !BCrypt.Net.BCrypt.Verify(authenticateRequest.Password, userEntity.HashedPassword))
            {
                throw new ApiException("Username or password is incorrect");
            }
            var response = _mapper.Map<UserAuthenticateResponsePackage>(userEntity);
            response.Token = _jwtUtils.GenerateToken(userEntity);
            _userSessionRepository.Insert(new UserSessionEntity { JwtToken=response.Token,UserId=userEntity.Id});
            return response;
        }

        public async Task<UserAuthenticateResponsePackage> Register(UserRegisterRequestPackage userRegisterRequestPackage)
        {
            var userEntity = await _userEntityRepository.GetUserEntity(userRegisterRequestPackage.EmailAddress);
            if (userEntity != null)
            {
                throw new ApiException("EmailAddress '" + userRegisterRequestPackage.EmailAddress + "' is already taken");
            }
            userEntity = _mapper.Map<UserEntity>(userRegisterRequestPackage);
            userEntity.HashedPassword = BCrypt.Net.BCrypt.HashPassword(userRegisterRequestPackage.Password);
            userEntity.FullName = userRegisterRequestPackage.FirstName + " " + userRegisterRequestPackage.LastName;
            await _userEntityRepository.SaveUserEntity(userEntity);
            var response = _mapper.Map<UserAuthenticateResponsePackage>(userEntity);
            response.Token = _jwtUtils.GenerateToken(userEntity);
            _userSessionRepository.Insert(new UserSessionEntity { JwtToken = response.Token, UserId = userEntity.Id });
            return response;
        }

        /// <summary>
        /// SendOtp
        /// </summary>
        /// <param name="sendOtpRequestPackage"></param>
        /// <returns></returns>
        public async Task<GenericServiceResponsePackage> SendOtp(SendOtpRequestPackage sendOtpRequestPackage)
        {
            var userEntity = await _userEntityRepository.GetUserEntity(sendOtpRequestPackage.EmailAddress);
            var otpCode = OtpHelper.GenerateOtpCode;
            var mailRequest = new Common.RequestModels.Email.MailRequest
            {
                Subject = "Confirmation email for account activation",
                Body = "Sayın " + userEntity.FullName + ", Hesabınızı aktifleştirmek için gerekli doğrulama kodunuz: " + otpCode + " Lütfen güvenlik açısından doğrulama kodunuzu kimseyle paylaşmayınız.",
                ToEmail = sendOtpRequestPackage.EmailAddress,
                ToName = userEntity.FullName
            };
            _userOtpRepository.Insert(new UserOtpEntity { OtpCode = otpCode, UserId = userEntity.Id });
            await _mailService.SendEmailByNetSmtp(mailRequest);
            return new GenericServiceResponsePackage { Success = true };
        }

        /// <summary>
        /// VerifyOtp
        /// </summary>
        /// <param name="verifyOtpRequestPackage"></param>
        /// <returns></returns>
        /// <exception cref="ApiException"></exception>
        public async Task<GenericServiceResponsePackage> VerifyOtp(VerifyOtpRequestPackage verifyOtpRequestPackage)
        {
            var success = false;
            var userEntity = await _userEntityRepository.GetUserEntity(verifyOtpRequestPackage.EmailAddress);
            if (userEntity == null)
            {
                throw new ApiException("Girilen E-mail adresine kayıtlı bir kullanıcı bulunamadı.");
            }
            var getUserOtpEntityRequestPackage = _mapper.Map<VerifyOtpRequestPackage, GetUserOtpEntityRequestPackage>(verifyOtpRequestPackage);
            var userOtpEntity = await _userOtpRepository.GetUserOtpEntity(getUserOtpEntityRequestPackage);
            if (userOtpEntity != null)
            {
                userEntity.EmailAddressConfirmed = true;
                userOtpEntity.ExpirationDate = DateTime.UtcNow;
                _userEntityRepository.Update(userEntity);
                _userOtpRepository.Update(userOtpEntity);
                success = true;
            }
            return new GenericServiceResponsePackage { Success = success };
        }

        public async Task<GenericServiceResponsePackage> ActivateUser(UserActivationRequestPackage userActivationRequestPackage)
        {
            var success = false;
            var userEntity = await _userEntityRepository.GetUserEntityByActivationCode(userActivationRequestPackage);
            if (userEntity != null)
            {
                userEntity.EmailAddressConfirmed = true;
                _userEntityRepository.Update(userEntity);
                success = true;
            }
            return new GenericServiceResponsePackage { Success = success };
        }

        public async Task<GenericServiceResponsePackage> ForgotPassword(UserForgotPasswordRequestPackage userForgotPasswordRequestPackage)
        {
            var userEntity = await _userEntityRepository.GetUserEntity(userForgotPasswordRequestPackage.EmailAddress);
            if (userEntity == null)
            {
                throw new ApiException("Girilen E-mail adresine kayıtlı bir kullanıcı bulunamadı.");
            }
            if (!userEntity.EmailAddressConfirmed)
            {
                throw new ApiException("Şifre sıfırlama işleminden önce, hesabınızı aktifleştirmelisiniz.");
            }
            Random r = new Random();
            var otpCode = r.Next(100000, 999999).ToString();
            var mailRequest = new Common.RequestModels.Email.MailRequest
            {
                Subject = "Şifre Yenileme",
                Body = "Sayın " + userEntity.FullName + ", Şifrenizi yeniden belirlemek için gerekli doğrulama kodunuz: " + otpCode + " Lütfen güvenlik açısından doğrulama kodunuzu kimseyle paylaşmayınız.",
                ToEmail = userForgotPasswordRequestPackage.EmailAddress,
                ToName = userEntity.FullName
            };
            _userOtpRepository.Insert(new UserOtpEntity { OtpCode = otpCode, UserId = userEntity.Id });
            await _mailService.SendEmailByNetSmtp(mailRequest);
            return new GenericServiceResponsePackage { Success = true };
        }

        public async Task<GenericServiceResponsePackage> ChangePassword(UserChangePasswordRequestPackage userChangePasswordRequestPackage)
        {
            var success = false;
            var getUserOtpEntityRequestPackage = _mapper.Map<UserChangePasswordRequestPackage, GetUserOtpEntityRequestPackage>(userChangePasswordRequestPackage);
            var userOtpEntity = await _userOtpRepository.GetUserOtpEntity(getUserOtpEntityRequestPackage);
            if (userOtpEntity != null)
            {
                var userEntity = await _userEntityRepository.GetUserEntityById(userOtpEntity.UserId);
                userEntity.HashedPassword = BCrypt.Net.BCrypt.HashPassword(userChangePasswordRequestPackage.Password);
                _userEntityRepository.Update(userEntity);
                success= true;
            }
            return new GenericServiceResponsePackage { Success = success };
        }
    }
}