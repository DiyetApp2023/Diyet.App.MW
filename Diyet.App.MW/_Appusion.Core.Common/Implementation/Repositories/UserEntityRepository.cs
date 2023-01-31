using Appusion.Core.Common.Entities.User;
using Appusion.Core.Common.Implementation.DbContexts;
using Appusion.Core.Common.Interface.Repositories;
using Appusion.Core.Common.Models.User;
using Microsoft.EntityFrameworkCore;
using Misyon.Core.Common.Entities.Misyon;
using Misyon.Core.Common.Implementation.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Implementation.Repositories
{
    public class UserEntityRepository : GenericRepository<UserEntity, DietDbContext>, IUserEntityRepository
    {
        public UserEntityRepository(DietDbContext context) : base(context)
        {
        }

        public void DeleteUserEntity(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserEntity> GetAllUserEntities()
        {
            throw new NotImplementedException();
        }

        public UserEntity GetUserEntity(string emailAddress)
        {
            var userEntity = DbContext.User.SingleOrDefault(x => x.EmailAddress == emailAddress);
            return userEntity;
        }

        public UserEntity GetUserEntityByActivationCode(UserActivation userActivation)
        {
            var userEntity = (from user in DbContext.User
                              join userActivationEntity in DbContext.UserActivation on user.Id equals userActivationEntity.UserId
                              where (userActivationEntity.ActivationCode == userActivation.ActivationCode)
                              select user).FirstOrDefault();
            return userEntity;
        }

        public UserEntity GetUserEntityById(int Id)
        {
            throw new NotImplementedException();
        }

        public void SaveUserEntity(UserEntity userEntity)
        {
            Insert(userEntity);
        }

        public void UpdateUserEntity(int id, UpdateRequest model)
        {
            throw new NotImplementedException();
        }
    }

}
