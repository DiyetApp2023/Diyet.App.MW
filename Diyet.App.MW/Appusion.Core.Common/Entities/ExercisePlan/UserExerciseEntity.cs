using Appusion.Core.Common.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Entities.ExercisePlan
{
    /// <summary>
    /// UserExerciseEntity
    /// </summary>
    [Table("UserExercise", Schema = "Exercise")]
    public class UserExerciseEntity : EntityBase
    {
        public long Id { get; set; }

        public long UserExercisePlanMapId { get; set; }

        public long ExerciseId { get; set; }

        public double Quantity { get; set; }

        public int Iteration { get; set; }

    }
}