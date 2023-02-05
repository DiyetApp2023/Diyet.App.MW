using System.ComponentModel.DataAnnotations.Schema;
using Appusion.Core.Common.Base;

namespace Appusion.Core.Common.Entities.User
{
    /// <summary>
    /// UserActivation
    /// </summary>
    [Table("UserActivation", Schema = "Diet")]
    public class UserActivationEntity : EntityBase
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public string ActivationCode { get; set; }
    }
}