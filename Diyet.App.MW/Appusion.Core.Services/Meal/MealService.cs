using Appusion.Core.BaseModels;
using Appusion.Core.Common.Interface.Services;
using Appusion.Core.Common.RequestModels.User;
using Appusion.Core.Common.ResponseModels.Meal;
using Appusion.Core.Common.ResponseModels.User;
using Appusion.Core.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Services.Meal
{
    public class MealService : Base.ServiceBase, IMealService
    {
        private readonly MealComponent _mealComponent;

        public MealService(MealComponent mealComponent)
        {
            _mealComponent = mealComponent;
        }
        public async Task<GenericServiceResult<List<GetMealListResponsePackage>>> GetMealList()
        {
            return await this.RunSafelyAsync(() =>
            {
                return _mealComponent.GetMealList().Result;
            });
        }
    }
}