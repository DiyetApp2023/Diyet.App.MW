using Appusion.Core.Common.Base;

using System.ComponentModel.DataAnnotations.Schema;

namespace Appusion.Core.Common.Entities.DietPlan
{
    /// <summary>
    /// UserDietPlanMapEntity
    /// </summary>
    [Table("UserDietPlanMap", Schema = "Diet")]
    public class UserDietPlanMapEntity : EntityBase
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public long PlanId { get; set; }
    }
}