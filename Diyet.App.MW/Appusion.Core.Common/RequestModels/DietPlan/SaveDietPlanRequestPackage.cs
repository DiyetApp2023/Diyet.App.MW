using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.RequestModels.DietPlan
{
    public class SaveDietPlanRequestPackage
    {
        public long Id { get; set; }

        public string PlanName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? Description { get; set; }
    }
}