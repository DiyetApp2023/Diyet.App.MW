using Appusion.Core.BaseModels;
using Appusion.Core.Common.Interface.Services;
using Appusion.Core.Common.RequestModels.DietPlan;
using Appusion.Core.Common.RequestModels.ExercisePlan;
using Appusion.Core.Common.ResponseModels.DietPlan;
using Appusion.Core.Common.ResponseModels.ExercisePlan;
using Appusion.Core.Services.Base;
using Appusion.Core.Services.DietPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Services.ExercisePlan
{
    public class ExercisePlanService : Base.ServiceBase, IExercisePlanService
    {
        private readonly ExercisePlanComponent _exercisePlanComponent;

        public ExercisePlanService(ExercisePlanComponent exercisePlanComponent)
        {
            _exercisePlanComponent = exercisePlanComponent;
        }

        public async Task<GenericServiceResult<List<GetAllExerciseListResponsePackage>>> GetAllExerciseList()
        {
            return await this.RunSafelyAsync(() =>
            {
                return _exercisePlanComponent.GetAllExerciseList().Result;
            });
        }

        public async Task<GenericServiceResult<SaveExercisePlanRequestPackage>> GetExercisePlan()
        {
            return await this.RunSafelyAsync(() =>
            {
                return _exercisePlanComponent.GetExercisePlan().Result;
            });
        }

        public async Task<GenericServiceResult<List<GetAllExerciseListResponsePackage>>> GetSearchedExerciseList(GetSearchedExerciseListRequestPackage getSearchedExerciseListRequestPackage)
        {
            return await this.RunSafelyAsync(() =>
            {
                return _exercisePlanComponent.GetSearchedExerciseList(getSearchedExerciseListRequestPackage).Result;
            });
        }

        public async Task<GenericServiceResult<SaveExercisePlanResponsePackage>> SaveExercisePlan(SaveExercisePlanRequestPackage saveExercisePlanRequestPackage)
        {
            return await this.RunSafelyAsync(() =>
            {
                return _exercisePlanComponent.SaveExercisePlan(saveExercisePlanRequestPackage).Result;
            });
        }

        public async Task<GenericServiceResult> SaveUserExercises(SaveUserExercisesRequestPackage saveUserExercisesRequests)
        {
            return await this.RunSafelyAsync(() =>
            {
                return _exercisePlanComponent.SaveUserExercises(saveUserExercisesRequests);
            });
        }
    }
}
