using Appusion.Core.Common.Base;

using System.ComponentModel.DataAnnotations.Schema;

namespace Appusion.Core.Common.Entities.ExercisePlan
{
    /// <summary>
    /// UserExercisePlanMapEntity
    /// </summary>
    [Table("UserExercisePlanMap", Schema = "Diet")]
    public class UserExercisePlanMapEntity : EntityBase
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public long ExercisePlanId { get; set; }
    }
}