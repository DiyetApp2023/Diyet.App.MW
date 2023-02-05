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
    /// ProductUnitEntity
    /// </summary>
    [Table("ProductUnit", Schema = "Diet")]
    public class ProductUnitEntity : EntityBase
    {
        public int Id { get; set; }

        public string UnitName { get; set; }
    }
}
