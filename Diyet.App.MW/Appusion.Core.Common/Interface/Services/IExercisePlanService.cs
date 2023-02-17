using Appusion.Core.BaseModels;
using Appusion.Core.Common.RequestModels.DietPlan;
using Appusion.Core.Common.RequestModels.ExercisePlan;
using Appusion.Core.Common.RequestModels.Product;
using Appusion.Core.Common.ResponseModels.DietPlan;
using Appusion.Core.Common.ResponseModels.ExercisePlan;
using Appusion.Core.Common.ResponseModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Interface.Services
{
    public interface IExercisePlanService
    {
        Task<GenericServiceResult<SaveExercisePlanRequestPackage>> GetExercisePlan();
        Task<GenericServiceResult<SaveExercisePlanResponsePackage>> SaveExercisePlan(SaveExercisePlanRequestPackage saveExercisePlanRequestPackage);
        Task<GenericServiceResult<List<GetAllExerciseListResponsePackage>>> GetAllExerciseList();
        Task<GenericServiceResult<List<GetAllExerciseListResponsePackage>>> GetSearchedExerciseList(GetSearchedExerciseListRequestPackage getSearchedExerciseListRequestPackage);
    }
}