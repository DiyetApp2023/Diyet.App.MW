using System;
using System.ComponentModel.DataAnnotations.Schema;
using Appusion.Core.Common.Base;

namespace Appusion.Core.Common.Entities.DietPlan
{
    /// <summary>
    /// UserDietPlanDetail
    /// </summary>
    [Table("UserDietPlanDetail", Schema = "Diet")]
    public class UserDietPlanDetailEntity: EntityBase
    {
        public long Id { get; set; }

        public long PlanId { get; set; }

        public int MealId { get; set; }
    }
}