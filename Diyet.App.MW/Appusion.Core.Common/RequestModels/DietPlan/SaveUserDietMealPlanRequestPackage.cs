using System;
namespace Appusion.Core.Common.RequestModels.DietPlan
{
	public class SaveUserDietMealPlanRequestPackage
	{
		public long PlanId { get; set; }

		public int  MealId { get; set; }

		public TimeSpan? StartTime { get; set; } 

        public TimeSpan? EndTime { get; set; }

		public double? EstimatedCalorie { get; set; }

		public List<UserDietPlanMealDetailProductMapRequestPackage> ProductDetails { get; set; }

		public SaveUserDietMealPlanRequestPackage()
		{
            ProductDetails = new List<UserDietPlanMealDetailProductMapRequestPackage> { };
        }
	}
}