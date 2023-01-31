using System.ComponentModel.DataAnnotations.Schema;

namespace Misyon.Core.Common.Entities.Misyon
{
    [Table("TempSession", Schema = "Sdk")]
    public class TempSession : EntityBase
    {
        public long Id { get; set; }

        public int PersonId { get; set; }

        public int ApplicationId { get; set; }

        public string TempSessionCookie { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreateDate { get; set; }= DateTime.Now;

        public DateTime? ExpireDate { get; set; }
    }
}