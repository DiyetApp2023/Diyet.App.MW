using Appusion.Core.BaseModels;
using Appusion.Core.Common.Interface.Services;
using Appusion.Core.Common.RequestModels.DietPlan;
using Appusion.Core.Common.RequestModels.User;
using Appusion.Core.Common.ResponseModels.DietPlan;
using Appusion.Core.Common.ResponseModels.General;
using Appusion.Core.Common.ResponseModels.Meal;
using Appusion.Core.Services.Base;
using Appusion.Core.Services.Meal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Services.DietPlan
{
    public class DietPlanService : Base.ServiceBase, IDietPlanService
    {
        private readonly DietPlanComponent _dietPlanComponent;

        public DietPlanService(DietPlanComponent dietPlanComponent)
        {
            _dietPlanComponent = dietPlanComponent;
        }

        /// <summary>
        /// SaveDietPlan
        /// </summary>
        /// <param name="saveDietPlanRequestPackage"></param>
        /// <returns></returns>
        public async Task<GenericServiceResult<GenericServiceResponsePackage>> SaveDietPlan(SaveDietPlanRequestPackage saveDietPlanRequestPackage)
        {
            return await this.RunSafelyAsync(() =>
            {
                return _dietPlanComponent.SaveDietPlan(saveDietPlanRequestPackage).Result;
            });
        }

        /// <summary>
        /// GetDietPlan
        /// </summary>
        /// <param name="genericUserRequestPackage"></param>
        /// <returns></returns>
        public async Task<GenericServiceResult<GetDietPlanResponsePackage>> GetDietPlan()
        {
            return await this.RunSafelyAsync(() =>
            {
                return _dietPlanComponent.GetDietPlan().Result;
            });
        }
    }
}
