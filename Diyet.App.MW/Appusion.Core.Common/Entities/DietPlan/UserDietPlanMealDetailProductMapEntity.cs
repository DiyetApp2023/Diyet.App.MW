using System.ComponentModel.DataAnnotations.Schema;
using Appusion.Core.Common.Base;

namespace Appusion.Core.Common.Entities.DietPlan
{
    /// <summary>
    /// UserDietPlanMealDetailProductMap
    /// </summary>
    [Table("UserDietPlanMealDetailProductMap", Schema = "Diet")]
    public class UserDietPlanMealDetailProductMapEntity : EntityBase
    {
        public long Id { get; set; }

        public long UserDietPlanDetailId { get; set; }

        public int ProductId { get; set; }

        public int UnitId { get; set; }

        public double Quantity { get; set; }

        public int Order { get; set; }
    }
}