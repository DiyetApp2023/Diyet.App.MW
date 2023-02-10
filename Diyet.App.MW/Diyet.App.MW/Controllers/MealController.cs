
using Appusion.Core.BaseModels;
using Appusion.Core.Common.Interface.Services;
using Appusion.Core.Common.RequestModels.User;
using Appusion.Core.Common.ResponseModels.General;
using Appusion.Core.Common.ResponseModels.Meal;
using Appusion.Core.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Appusion.Core.Services.Api.Controllers
{
    /// <summary>
    /// MealController
    /// </summary>
    public class MealController: System.Web.Http.ApiController
    {
        private readonly IMealService _mealService;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="mealService"></param>
        public MealController(IMealService mealService)
        {
            _mealService = mealService;
        }

        /// <summary>
        /// GetMealList
        /// </summary>
        /// <returns></returns>
        [Route("api/meal/getmeallist")]
        [HttpGet]
        public async Task<GenericServiceResult<List<GetMealListResponsePackage>>> GetMealList()
        {
            return await _mealService.GetMealList();
        }


        /// <summary>
        /// GetDefaultScheduledMealList
        /// </summary>
        /// <returns></returns>
        [Route("api/meal/getdefaultscheduledmeallist")]
        [HttpGet]
        public async Task<GenericServiceResult<List<GetDefaultScheduledMealListResponsePackage>>> GetDefaultScheduledMealList()
        {
            return await _mealService.GetDefaultScheduledMealList();
        }
    }
}