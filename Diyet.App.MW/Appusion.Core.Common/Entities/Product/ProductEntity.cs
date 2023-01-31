using Appusion.Core.Common.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Entities.Product
{
    /// <summary>
    /// ProductEntity
    /// </summary>
    [Table("Product", Schema = "Diet")]
    public class ProductEntity : EntityBase
    {
        public int Id { get; set; }

        public string ProductName { get; set; }
    }
}
