using Appusion.Core.Common.RequestModels.DietPlan;
using Appusion.Core.Common.ResponseModels.Meal;
using Appusion.Core.Common.ResponseModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.ResponseModels.DietPlan
{
        public class GetUserDietMealPlanResponsePackage 
        {
        public long PlanId { get; set; }

        public string PlanName { get; set; }

        public List<UserMealDetailResponsePackage> MealDetails { get; set; }
    }
}