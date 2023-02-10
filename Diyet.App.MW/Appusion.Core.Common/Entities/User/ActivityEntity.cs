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
    /// ActivityEntity
    /// </summary>
    [Table("Activity", Schema = "Diet")]
    public class ActivityEntity : EntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
