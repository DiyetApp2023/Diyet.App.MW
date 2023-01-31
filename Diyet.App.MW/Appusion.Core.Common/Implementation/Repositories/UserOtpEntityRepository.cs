using Appusion.Core.Common.Entities.User;
using Appusion.Core.Common.Implementation.DbContexts;
using Appusion.Core.Common.Interface.Repositories;
using Appusion.Core.Common.RequestModels.User;

namespace Appusion.Core.Common.Implementation.Repositories
{
    public class UserOtpEntityRepository : GenericRepository<UserOtpEntity, DietDbContext>, IUserOtpEntityRepository
    {
        public UserOtpEntityRepository(DietDbContext context) : base(context)
        {
        }

        public async Task<UserOtpEntity> GetUserOtpEntity(UserChangePasswordRequestPackage userChangePasswordRequestPackage)
        {
            var userOtpEntity = (from user in DbContext.User
                              join userOtp in DbContext.UserOtp on user.Id equals userOtp.UserId
                              where (userOtp.OtpCode == userChangePasswordRequestPackage.OtpCode && user.EmailAddress == userChangePasswordRequestPackage.EmailAddress)
                              select userOtp).FirstOrDefault();
            return userOtpEntity;
        }
    }
}
