using Appusion.Core.Common.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Entities.Meal
{
    /// <summary>
    /// MealEntity
    /// </summary>
    [Table("Meal", Schema = "Diet")]
    public class MealEntity: EntityBase
    {
        public int Id { get; set; }

        public string MealName { get; set; }

        public bool IsActive { get; set; }
    }
}