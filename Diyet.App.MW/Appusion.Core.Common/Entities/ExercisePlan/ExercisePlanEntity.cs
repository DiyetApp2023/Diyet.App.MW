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
    [Table("ExercisePlan", Schema = "Exercise")]
    public class ExercisePlanEntity: EntityBase
    {
        public long Id { get; set; }

        public string PlanName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}