using Appusion.Core.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.ResponseModels.User
{
    public class GetUserDailyActivityResponsePackage
    {
        public string ActivityName { get; set; }

        public ActivityType ActivityType { get; set; }

        public double ActivityValue { get; set; }
    }
}
