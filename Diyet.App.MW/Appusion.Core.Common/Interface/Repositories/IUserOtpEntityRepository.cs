using Appusion.Core.Common.Entities.User;
using Appusion.Core.Common.RequestModels.User;


namespace Appusion.Core.Common.Interface.Repositories
{
    public interface IUserOtpEntityRepository : IGenericRepository<UserOtpEntity>
    {
        Task<UserOtpEntity> GetUserOtpEntity(UserChangePasswordRequestPackage userChangePasswordRequestPackage);
    }
}
