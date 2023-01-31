using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Appusion.Core.Common.Models.User
{
    public class RegisterRequest
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

        public DateTime CreateDate { get; set; }

        [Required]
        public string Password { get; set; }
    }
}