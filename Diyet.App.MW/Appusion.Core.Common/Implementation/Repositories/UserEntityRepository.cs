using Appusion.Core.Common.Entities.User;
using Appusion.Core.Common.Implementation.DbContexts;
using Appusion.Core.Common.Interface.Repositories;
using Appusion.Core.Common.RequestModels.User;


namespace Appusion.Core.Common.Implementation.Repositories
{
    public class UserEntityRepository : GenericRepository<UserEntity, DietDbContext>, IUserEntityRepository
    {
        public UserEntityRepository(DietDbContext context) : base(context)
        {
        }
        public async Task<UserEntity> GetUserEntity(string emailAddress)
        {
            var userEntity = DbContext.User.SingleOrDefault(x => x.EmailAddress == emailAddress);
            return userEntity;
        }

        public async Task<UserEntity> GetUserEntityByActivationCode(UserActivationRequestPackage userActivationRequestPackage)
        {
            var userEntity = (from user in DbContext.User
                              join userActivationEntity in DbContext.UserActivation on user.Id equals userActivationEntity.UserId
                              where (userActivationEntity.ActivationCode == userActivationRequestPackage.ActivationCode)
                              select user).FirstOrDefault();
            return userEntity;
        }

        public async Task<UserEntity> GetUserEntityById(long userId)
        {
                var userEntity = DbContext.User.SingleOrDefault(x => x.Id == userId);
                return userEntity;
        }

        public async Task SaveUserEntity(UserEntity userEntity)
        {
            await Insert(userEntity);
        }
    }

}
