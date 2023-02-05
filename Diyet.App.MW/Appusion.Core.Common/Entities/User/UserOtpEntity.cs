using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appusion.Core.Common.Base;

namespace Appusion.Core.Common.Entities.User
{
    /// <summary>
    /// User
    /// </summary>
    [Table("UserOtp", Schema = "Diet")]
    public class UserOtpEntity : EntityBase
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public string OtpCode { get; set; }

        public DateTime ExpirationDate { get; set; } = DateTime.Now.AddDays(7);
    }
}
