using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.ResponseModels.Meal
{
    public class GetDefaultScheduledMealListResponsePackage : GetMealListResponsePackage
    {
        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
    }
}
