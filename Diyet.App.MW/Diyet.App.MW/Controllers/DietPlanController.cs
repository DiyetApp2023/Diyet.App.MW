
using Appusion.Core.BaseModels;
using Appusion.Core.Common.Interface.Services;
using Appusion.Core.Common.RequestModels.DietPlan;
using Appusion.Core.Common.RequestModels.Product;
using Appusion.Core.Common.RequestModels.User;
using Appusion.Core.Common.ResponseModels.DietPlan;
using Appusion.Core.Common.ResponseModels.General;
using Appusion.Core.Common.ResponseModels.Meal;
using Appusion.Core.Common.ResponseModels.Product;
using Appusion.Core.Common.ResponseModels.User;
using Appusion.Core.Services.User;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Appusion.Core.Services.Api.Controllers
{
    /// <summary>
    /// ProductController
    /// </summary>
    public class DietPlanController : System.Web.Http.ApiController
    {
        private readonly IDietPlanService _dietPlanService;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="mealService"></param>
        public DietPlanController(IDietPlanService dietPlanService)
        {
            _dietPlanService = dietPlanService;
        }

        /// <summary>
        /// SaveDietPlan
        /// </summary>
        /// <param name="saveDietPlanRequestPackage"></param>
        /// <returns></returns>
        [Route("api/dietplan/savedietplan")]
        [HttpPost]
        public async Task<GenericServiceResult<SaveDietPlanResponsePackage>> SaveDietPlan([FromBody] SaveDietPlanRequestPackage saveDietPlanRequestPackage)
        {
            return await _dietPlanService.SaveDietPlan(saveDietPlanRequestPackage);
        }

        /// <summary>
        /// GetDietPlan
        /// </summary>
        /// <param name="genericUserRequestPackage"></param>
        /// <returns></returns>
        [Route("api/dietplan/getdietplan")]
        [HttpGet]
        public async Task<GenericServiceResult<GetDietPlanResponsePackage>> GetDietPlan()
        {
            return await _dietPlanService.GetDietPlan();
        }

        // TODO : Bir kişinin her bir öğünde tüketeceği ürünler ve bu ürünlerin birimleri ve miktarlarını dönen servis

        /// <summary>
        /// SaveUserDietMealPlan
        /// </summary>
        /// <param name="saveUserDietMealPlanRequestPackage"></param>
        /// <returns></returns>
        [Route("api/dietplan/saveuserdietmealplan")]
        [HttpPost]
        public async Task<GenericServiceResult<GenericServiceResponsePackage>> SaveUserDietMealPlan([FromBody]SaveUserDietMealPlanRequestPackage saveUserDietMealPlanRequestPackage)
        {
            return await _dietPlanService.SaveUserDietMealPlan(saveUserDietMealPlanRequestPackage);
        }

        /// <summary>
        /// GetDietPlan
        /// </summary>
        /// <param name="genericUserRequestPackage"></param>
        /// <returns></returns>
        [Route("api/dietplan/getuserdietmealplan")]
        [HttpGet]
        public async Task<GenericServiceResult<GetUserDietMealPlanResponsePackage>> GetUserDietMealPlan()
        {
            return await _dietPlanService.GetUserDietMealPlan();
        }

        /// <summary>
        /// SaveUserDailyActivity
        /// </summary>
        /// <param name="saveUserDailyActivityRequestPackage"></param>
        /// <returns></returns>
        [Route("api/dietplan/saveuserdailyactivity")]
        [HttpPost]
        public async Task<GenericServiceResult<GenericServiceResponsePackage>> SaveUserDailyActivity([FromBody] SaveUserDailyActivityRequestPackage saveUserDailyActivityRequestPackage)
        {
            return await _dietPlanService.SaveUserDailyActivity(saveUserDailyActivityRequestPackage);
        }

        /// <summary>
        /// GetUserDailyActivityList
        /// </summary>
        /// <returns></returns>
        [Route("api/dietplan/getuserdailyactivitylist")]
        [HttpGet]
        public async Task<GenericServiceResult<List<GetUserDailyActivityResponsePackage>>> GetUserDailyActivityList()
        {
            return await _dietPlanService.GetUserDailyActivityList();
        }
    }
}