using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Appusion.Core.Common.RequestModels.User
{
    public class UserRegisterRequestPackage
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [JsonIgnore]
        public string FullName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string GsmNumber { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [JsonIgnore]
        public string HashedPassword { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        [Required]
        public string Password { get; set; }
    }
}