using Appusion.Core.Common.Entities.User;
using Appusion.Core.Common.Models.User;
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
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<UserEntity> GetAll();
        UserEntity GetById(int id);
        void Register(RegisterRequest model);
        void Update(int id, UpdateRequest model);
        void Delete(int id);
        void ActivateUser(UserActivation userActivation);
    }
}
