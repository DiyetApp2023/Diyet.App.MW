using Appusion.Core.BaseModels;
using Appusion.Core.Common.RequestModels.DietPlan;
using Appusion.Core.Common.RequestModels.User;
using Appusion.Core.Common.ResponseModels.DietPlan;
using Appusion.Core.Common.ResponseModels.General;
using Appusion.Core.Common.ResponseModels.User;

namespace Appusion.Core.Common.Interface.Services
{
    public interface IDietPlanService
    {
        Task<GenericServiceResult<GetDietPlanResponsePackage>> GetDietPlan();
        Task<GenericServiceResult<SaveDietPlanResponsePackage>> SaveDietPlan(SaveDietPlanRequestPackage saveDietPlanRequestPackage);
        Task<GenericServiceResult<GenericServiceResponsePackage>> SaveUserDietMealPlan(SaveUserDietMealPlanRequestPackage saveUserDietMealPlanRequestPackage);
        Task<GenericServiceResult<GetUserDietMealPlanResponsePackage>> GetUserDietMealPlan();
        Task<GenericServiceResult<GenericServiceResponsePackage>> SaveUserDailyActivity(SaveUserDailyActivityRequestPackage saveUserDailyActivityRequestPackage);
        Task<GenericServiceResult<List<GetUserDailyActivityResponsePackage>>> GetUserDailyActivityList(DateTime activityDate);

    }
}