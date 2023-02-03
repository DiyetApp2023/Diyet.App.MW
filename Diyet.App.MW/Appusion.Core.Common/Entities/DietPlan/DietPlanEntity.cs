using Appusion.Core.Common.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Entities.DietPlan
{
    /// <summary>
    /// DietPlanEntity
    /// </summary>
    [Table("DietPlan", Schema = "Diet")]
    public class DietPlanEntity: EntityBase
    {
        public long Id { get; set; }

        public string PlanName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;
    }
}