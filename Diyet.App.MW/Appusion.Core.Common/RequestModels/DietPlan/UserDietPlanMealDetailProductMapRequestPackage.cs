﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.RequestModels.DietPlan
{
    public class UserDietPlanMealDetailProductMapRequestPackage
    {
        public int ProductId { get; set; }

        public int UnitId { get; set; }

        public float Quantity { get; set; }

        public int Order { get; set; }
    }
}