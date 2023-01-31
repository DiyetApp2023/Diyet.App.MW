using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misyon.Core.Common.Entities.Misyon
{
    /// <summary>
    /// PageDefinition
    /// </summary>
    [Table("PageDefinition", Schema = "Sdk")]
    public class PageDefinition : EntityBase
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// PageName
        /// </summary>
        public string PageName { get; set; }

        /// <summary>
        /// PageOrder
        /// </summary>
        public int PageOrder { get; set; }

        /// <summary>
        /// CreateDate
        /// </summary>
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}