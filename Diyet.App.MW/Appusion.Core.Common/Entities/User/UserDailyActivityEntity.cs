using Appusion.Core.Common.Base;
using Appusion.Core.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Entities.User
{
    /// <summary>
    /// UserDailyActivityEntity
    /// </summary>
    [Table("UserDailyActivity", Schema = "Diet")]
    public class UserDailyActivityEntity: EntityBase
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public ActivityType ActivityType { get; set; }

        public double ActivityValue { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.UtcNow.Date;
    }
}
