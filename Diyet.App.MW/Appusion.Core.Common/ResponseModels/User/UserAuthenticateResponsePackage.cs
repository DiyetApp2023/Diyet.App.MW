using Appusion.Core.Common.ResponseModels.Jwt;

namespace Appusion.Core.Common.ResponseModels.User
{
    public class UserAuthenticateResponsePackage
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        public TokenResponsePackage TokenInfo { get; set; }
    }
}
