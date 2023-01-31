using Appusion.Core.Common.Entities.User;
using Appusion.Core.Common.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Interface.Repositories
{
    public interface IUserEntityRepository : IGenericRepository<UserEntity>
    {
        UserEntity GetUserEntity(string emailAddress);

        IEnumerable<UserEntity> GetAllUserEntities();

        UserEntity GetUserEntityById(int Id);

        UserEntity GetById(int id);

        void UpdateUserEntity(int id, UpdateRequest model);

        void DeleteUserEntity(int id);

        void SaveUserEntity(UserEntity userEntity);

        UserEntity GetUserEntityByActivationCode(UserActivation userActivation);
    }
}