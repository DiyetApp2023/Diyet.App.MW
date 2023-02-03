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