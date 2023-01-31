using System.ComponentModel.DataAnnotations.Schema;


namespace Misyon.Core.Common.Entities.Misyon
{
    [Table("CustomerPageData", Schema = "Sdk")]
    public class CustomerPageData : EntityBase
    {
        public long ApplicationId { get; set; }

        public long PageId { get; set; }

        public string PageData { get; set; }

        public long Id { get; set; }

        public string? CreateUserName { get; set; }

        public string? CreateHostName { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
