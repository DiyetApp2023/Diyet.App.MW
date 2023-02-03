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
    /// ProductCategoryMapEntity
    /// </summary>
    [Table("ProductCategoryMap", Schema = "Diet")]
    public class ProductCategoryMapEntity : EntityBase
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int CategoryId { get; set; }
    }
}