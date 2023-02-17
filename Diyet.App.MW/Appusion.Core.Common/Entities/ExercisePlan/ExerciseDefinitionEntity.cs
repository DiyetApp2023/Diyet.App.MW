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
    /// DietPlanEntity
    /// </summary>
    [Table("ExerciseDefinition", Schema = "Exercise")]
    public class ExerciseDefinitionEntity: EntityBase
    {
        public long Id { get; set; }

        public string Name { get; set; }
        
        public bool IsActive { get; set; } = true;

    }
}