using Appusion.Core.Common.RequestModels.DietPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.ResponseModels.Meal
{
    public class UserMealDetailResponsePackage
    {
        public int MealId { get; set; }

        public string MealName { get; set; }

        public TimeSpan? StartTime { get; set; }

        public TimeSpan? EndTime { get; set; }

        public double? EstimatedCalorie { get; set; }

        public List<UserDietPlanMealDetailProductMapRequestPackage> ProductDetails { get; set; }

        public UserMealDetailResponsePackage()
        {
            ProductDetails = new List<UserDietPlanMealDetailProductMapRequestPackage> { };
        }
    }
}