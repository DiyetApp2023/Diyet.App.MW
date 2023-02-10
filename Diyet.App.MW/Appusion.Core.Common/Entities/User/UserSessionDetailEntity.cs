using Appusion.Core.Common.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Entities.User
{
    /// <summary>
    /// UserSessionDetailEntity
    /// </summary>
    [Table("UserSessionDetail", Schema = "Diet")]
    public class UserSessionDetailEntity: EntityBase
    {
        public long Id { get; set; }

        public long UserSessionId { get; set; }

        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpiration { get; set; }
    }
}