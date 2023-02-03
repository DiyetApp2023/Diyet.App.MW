using Appusion.Core.BaseModels;
using Appusion.Core.Common.Entities.User;
using Appusion.Core.Common.RequestModels.User;
using Appusion.Core.Common.ResponseModels.General;
using Appusion.Core.Common.ResponseModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Interface.Services
{
    // https://jasonwatmore.com/post/2022/01/07/net-6-user-registration-and-login-tutorial-with-example-api
    // https://stackoverflow.com/questions/74725963/asp-net-core-web-api-how-to-register-user-and-immediately-login-using-a-third
    public interface IUserService
    {
        Task<GenericServiceResult<UserAuthenticateResponsePackage>> Authenticate(UserAuthenticateRequestPackage userAuthenticateRequestPackage);
        Task<GenericServiceResult<GenericServiceResponsePackage>> Register(UserRegisterRequestPackage userRegisterRequestPackage);
        Task<GenericServiceResult<GenericServiceResponsePackage>> SendOtp(SendOtpRequestPackage sendOtpRequestPackage);
        Task<GenericServiceResult<GenericServiceResponsePackage>> VerifyOtp(VerifyOtpRequestPackage verifyOtpRequestPackage);
        Task<GenericServiceResult<GenericServiceResponsePackage>> ActivateUser(UserActivationRequestPackage userActivationRequestPackage);
        Task<GenericServiceResult<GenericServiceResponsePackage>> ForgotPassword(UserForgotPasswordRequestPackage userForgotPasswordRequestPackage);
        Task<GenericServiceResult<GenericServiceResponsePackage>> ChangePassword(UserChangePasswordRequestPackage userChangePasswordRequestPackage);
    }
}