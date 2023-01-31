using Appusion.Core.Common.Entities.User;
using Appusion.Core.Common.RequestModels.User;

namespace Appusion.Core.Common.Interface.Repositories
{
    public interface IUserEntityRepository : IGenericRepository<UserEntity>
    {
        Task<UserEntity> GetUserEntity(string emailAddress);

        Task SaveUserEntity(UserEntity userEntity);

        Task<UserEntity> GetUserEntityByActivationCode(UserActivationRequestPackage userActivationRequestPackage);

        Task<UserEntity> GetUserEntityById(long userId);
    }
}