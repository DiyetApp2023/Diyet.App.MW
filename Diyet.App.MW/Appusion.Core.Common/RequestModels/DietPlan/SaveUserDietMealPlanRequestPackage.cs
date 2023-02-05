using System;
namespace Appusion.Core.Common.RequestModels.DietPlan
{
	public class SaveUserDietMealPlanRequestPackage
	{
		public int ProductId { get; set; }

		public int  MealId { get; set; }

		public int UnitId { get; set; }

		public float Quantity { get; set; }
	}
}