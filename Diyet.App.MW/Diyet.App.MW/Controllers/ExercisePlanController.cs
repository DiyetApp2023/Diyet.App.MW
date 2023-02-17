
using Appusion.Core.BaseModels;
using Appusion.Core.Common.Interface.Services;
using Appusion.Core.Common.RequestModels.DietPlan;
using Appusion.Core.Common.RequestModels.ExercisePlan;
using Appusion.Core.Common.RequestModels.Product;
using Appusion.Core.Common.RequestModels.User;
using Appusion.Core.Common.ResponseModels.DietPlan;
using Appusion.Core.Common.ResponseModels.ExercisePlan;
using Appusion.Core.Common.ResponseModels.General;
using Appusion.Core.Common.ResponseModels.Meal;
using Appusion.Core.Common.ResponseModels.Product;
using Appusion.Core.Common.ResponseModels.User;
using Appusion.Core.Services.Product;
using Appusion.Core.Services.User;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Appusion.Core.Services.Api.Controllers
{
    /// <summary>
    /// ExercisePlanController
    /// </summary>
    public class ExercisePlanController : System.Web.Http.ApiController
    {
        private readonly IExercisePlanService _exercisePlanService;

        /// <summary>
        /// ExercisePlanController
        /// </summary>
        /// <param name="exercisePlanService"></param>
        public ExercisePlanController(IExercisePlanService exercisePlanService)
        {
            _exercisePlanService = exercisePlanService;
        }


        /// <summary>
        /// GetSearchedExerciseList
        /// </summary>
        /// <returns></returns>
        [Route("api/exercise/getsearchedexerciselist")]
        [HttpGet]
        public async Task<GenericServiceResult<List<GetAllExerciseListResponsePackage>>> GetSearchedExerciseList([FromQuery] GetSearchedExerciseListRequestPackage getSearchedExerciseListRequestPackage)
        {
            return await _exercisePlanService.GetSearchedExerciseList(getSearchedExerciseListRequestPackage);
        }   

        /// <summary>
        /// GetAllExerciseList
        /// </summary>
        /// <returns></returns>
        [Route("api/exercise/getallexerciselist")]
        [HttpGet]
        public async Task<GenericServiceResult<List<GetAllExerciseListResponsePackage>>> GetAllExerciseList()
        {
            return await _exercisePlanService.GetAllExerciseList();
        }

        /// <summary>
        /// SaveExercisePlan
        /// </summary>
        /// <returns></returns>
        [Route("api/exercise/saveexerciseplan")]
        [HttpPost]
        public async Task<GenericServiceResult<SaveExercisePlanResponsePackage>> SaveExercisePlan([FromBody] SaveExercisePlanRequestPackage saveExercisePlanRequestPackage)
        {
            return await _exercisePlanService.SaveExercisePlan(saveExercisePlanRequestPackage);
        }

        /// <summary>
        /// GetExercisePlan
        /// </summary>
        /// <returns></returns>
        [Route("api/exercise/getexerciseplan")]
        [HttpGet]
        public async Task<GenericServiceResult<SaveExercisePlanRequestPackage>> GetExercisePlan()
        {
            return await _exercisePlanService.GetExercisePlan();
        }

        /// <summary>
        /// SaveUserExercises
        /// </summary>
        /// <returns></returns>
        [Route("api/exercise/saveuserexercises")]
        [HttpPost]
        public async Task<GenericServiceResult> SaveUserExercises([FromBody] SaveUserExercisesRequestPackage userExerciseList)
        {
            return await _exercisePlanService.SaveUserExercises(userExerciseList);
        }
    }
}