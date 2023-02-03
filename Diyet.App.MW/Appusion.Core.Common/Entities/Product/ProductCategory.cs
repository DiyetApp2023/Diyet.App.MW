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
    /// ProductCategoryEntity
    /// </summary>
    [Table("ProductCategory", Schema = "Diet")]
    public class ProductCategoryEntity : EntityBase
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }
    }
}
