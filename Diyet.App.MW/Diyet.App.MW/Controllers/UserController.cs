using Appusion.Core.BaseModels;
using Appusion.Core.Common.Entities.User;
using Appusion.Core.Common.Interface.Services;
using Appusion.Core.Common.RequestModels.User;
using Appusion.Core.Common.ResponseModels.General;
using Appusion.Core.Common.ResponseModels.User;
using Microsoft.AspNetCore.Mvc;

namespace Appusion.Core.Services.Api.Controllers
{
    [System.Web.Http.Authorize]
    public class UserController: System.Web.Http.ApiController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// ActivateUser
        /// </summary>
        /// <param name="userActivationRequestPackage"></param>
        [Route("api/user/activateuser")]
        [HttpGet]
        public async Task<GenericServiceResult<GenericServiceResponsePackage>> ActivateUser([FromQuery]UserActivationRequestPackage userActivationRequestPackage )
        {
            return await _userService.ActivateUser(userActivationRequestPackage);
        }

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="userRegisterRequestPackage"></param>
        [Route("api/user/register")]
        [HttpPost]
        public async Task<GenericServiceResult<GenericServiceResponsePackage>> Register([FromBody] UserRegisterRequestPackage userRegisterRequestPackage)
        {
            return await _userService.Register(userRegisterRequestPackage);
        }

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="userAuthenticateRequestPackage"></param>
        /// <returns></returns>
        [Route("api/user/authenticate")]
        [HttpPost]
        public async Task<GenericServiceResult<UserAuthenticateResponsePackage>> Authenticate([FromBody] UserAuthenticateRequestPackage userAuthenticateRequestPackage)
        {
            return await _userService.Authenticate(userAuthenticateRequestPackage);
        }

        /// <summary>
        /// ForgotPassword
        /// </summary>
        /// <param name="userForgotPasswordRequestPackage"></param>
        /// <returns></returns>
        [Route("api/user/forgotpassword")]
        [HttpPost]
        public async Task<GenericServiceResult<GenericServiceResponsePackage>> ForgotPassword([FromBody] UserForgotPasswordRequestPackage userForgotPasswordRequestPackage)
        {
            return await _userService.ForgotPassword(userForgotPasswordRequestPackage);
        }

        /// <summary>
        /// ChangePassword
        /// </summary>
        /// <param name="userChangePasswordRequestPackage"></param>
        /// <returns></returns>
        [Route("api/user/changepassword")]
        [HttpPost]
        public async Task<GenericServiceResult<GenericServiceResponsePackage>> ChangePassword([FromBody] UserChangePasswordRequestPackage userChangePasswordRequestPackage)
        {
            return await _userService.ChangePassword(userChangePasswordRequestPackage);
        }
    }
}
