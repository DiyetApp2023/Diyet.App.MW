using Misyon.Core.Common.Entities.Misyon;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misyon.Core.Common.Entities.Boa
{
    [Table("Application", Schema = "Rca")]
    public class Application : EntityBase
    {
        /// <summary>
        /// ApplicationId
        /// </summary>
        public int ApplicationId { get; set; }

        /// <summary>
        /// IdentityNumber
        /// </summary>
        public string IdentityNumber { get; set; }

        /// <summary>
        /// PersonId
        /// </summary>
        public string PersonId { get; set; }

        /// <summary>
        /// CustomerId
        /// </summary>
        public string CustomerId { get; set; }
    }
}
