using Appusion.Core.BaseModels;
using Appusion.Core.Common.Entities.User;
using Appusion.Core.Common.Implementation.DbContexts;
using Appusion.Core.Common.Implementation.Repositories;
using Appusion.Core.Common.Interface.Repositories;
using Appusion.Core.Common.Interface.Services;
using Appusion.Core.Common.RequestModels.User;
using Appusion.Core.Common.ResponseModels;
using Appusion.Core.Common.ResponseModels.General;
using Appusion.Core.Common.ResponseModels.User;
using Appusion.Core.ExceptionBase;
using Appusion.Core.Services.Base;
using AutoMapper;
using BCrypt.Net;

namespace Appusion.Core.Services.User
{
    public class UserService : Base.ServiceBase, IUserService
    {
        private readonly UserComponent _userComponent;

        public UserService( UserComponent userComponent)
        {
            _userComponent = userComponent;
        }

        public async Task<GenericServiceResult<UserAuthenticateResponsePackage>> Authenticate(UserAuthenticateRequestPackage userAuthenticateRequestPackage)
        {
            return await this.RunSafelyAsync(() =>
            {
                return _userComponent.Authenticate(userAuthenticateRequestPackage).Result;
            });
        }

        public async Task<GenericServiceResult<GenericServiceResponsePackage>> Register(UserRegisterRequestPackage userRegisterRequestPackage)
        {
            return await this.RunSafelyAsync(() =>
            {
                return _userComponent.Register(userRegisterRequestPackage).Result;
            });
        }

        public async Task<GenericServiceResult<GenericServiceResponsePackage>> ActivateUser(UserActivationRequestPackage userActivationRequestPackage)
        {
            return await this.RunSafelyAsync(() =>
            {
                return _userComponent.ActivateUser(userActivationRequestPackage).Result;
            });
        }

        public async Task<GenericServiceResult<GenericServiceResponsePackage>> ForgotPassword(UserForgotPasswordRequestPackage userForgotPasswordRequestPackage)
        {
            return await this.RunSafelyAsync(() =>
            {
                return _userComponent.ForgotPassword(userForgotPasswordRequestPackage).Result;
            });
        }

        public async Task<GenericServiceResult<GenericServiceResponsePackage>> ChangePassword(UserChangePasswordRequestPackage userChangePasswordRequestPackage)
        {
            return await this.RunSafelyAsync(() =>
            {
                return _userComponent.ChangePassword(userChangePasswordRequestPackage).Result;
            });
        }
    }
}