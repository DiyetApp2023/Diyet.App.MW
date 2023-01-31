using Appusion.Core.Common.Entities.Misyon;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Entities.User
{
    /// <summary>
    /// UserActivation
    /// </summary>
    [Table("UserActivation", Schema = "Diet")]
    public class UserActivation : EntityBase
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public string ActivationCode { get; set; }
    }
}