using Appusion.Core.Common.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Interface.Repositories
{
    public interface IUserActivationRepository : IGenericRepository<UserActivation>
    {
        void SaveUserActivation(UserActivation userActivation);
    }
}