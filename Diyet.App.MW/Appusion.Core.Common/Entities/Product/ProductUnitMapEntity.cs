using Appusion.Core.Common.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Entities.Product
{
    /// <summary>
    /// ProductUnitMap
    /// </summary>
    [Table("ProductUnitMap", Schema = "Diet")]
    public class ProductUnitMapEntity : EntityBase
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int UnitId { get; set; }
    }
}