using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.RequestModels.DietPlan
{
    public class UserDietPlanMealDetailProductMapRequestPackage
    {
        public long Id { get; set; }

        public int ProductId { get; set; }

        public int UnitId { get; set; }

        public double Quantity { get; set; }

        public int Order { get; set; }
    }
}