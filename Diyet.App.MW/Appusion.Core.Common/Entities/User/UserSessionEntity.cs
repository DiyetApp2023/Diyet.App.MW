using Appusion.Core.Common.Base;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Entities.User
{
    /// <summary>
    /// UserSessionEntity
    /// </summary>
    [Table("UserSession", Schema = "Diet")]
    public class UserSessionEntity : EntityBase
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public string JwtToken { get; set; }

        public DateTime LogOnDate { get; set; } = DateTime.UtcNow;
    }
}