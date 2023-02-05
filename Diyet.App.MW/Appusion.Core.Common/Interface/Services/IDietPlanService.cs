using Appusion.Core.BaseModels;
using Appusion.Core.Common.RequestModels.DietPlan;
using Appusion.Core.Common.RequestModels.User;
using Appusion.Core.Common.ResponseModels.DietPlan;
using Appusion.Core.Common.ResponseModels.General;

namespace Appusion.Core.Common.Interface.Services
{
    public interface IDietPlanService
    {
        Task<GenericServiceResult<GetDietPlanResponsePackage>> GetDietPlan();
        Task<GenericServiceResult<GenericServiceResponsePackage>> SaveDietPlan(SaveDietPlanRequestPackage saveDietPlanRequestPackage);
        Task<GenericServiceResult<GenericServiceResponsePackage>> SaveUserMealPlan();
    }
}