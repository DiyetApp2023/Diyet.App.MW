using Appusion.Core.Common.Entities.User;
using Appusion.Core.Common.Interface.Services;
using Appusion.Core.Common.ResponseModels.Jwt;
using Appusion.Core.Common.Utility;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Services.Jwt
{
    public class JwtUtils : IJwtUtils
    {
        private readonly JwtHelper _jwtHelper;

        public JwtUtils(JwtHelper jwtHelper)
        {
            _jwtHelper = jwtHelper;
        }

        public async Task<TokenResponsePackage> GenerateAccessToken(UserEntity userEntity)
        {
            var accessTokenExpiration = DateTime.UtcNow.AddMinutes(_jwtHelper.GetJwtParameter.AccessTokenExpiration);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtHelper.GetJwtParameter.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", userEntity.Id.ToString()) }),
                Expires = accessTokenExpiration,
                Issuer = _jwtHelper.GetJwtParameter.Issuer,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(token);
            return new TokenResponsePackage
            {
                AccessToken = accessToken,
                AccessTokenExpiration = accessTokenExpiration
            };
        }

        public async Task<TokenResponsePackage> GenerateRefreshToken()
        {
            var numberByte = new Byte[32];
            using var rnd = RandomNumberGenerator.Create();
            rnd.GetBytes(numberByte);
            var refreshToken = Convert.ToBase64String(numberByte);
            var refreshTokenExpiration = DateTime.UtcNow.AddDays(_jwtHelper.GetJwtParameter.RefreshTokenExpiration);

            return new TokenResponsePackage
            {
                RefreshToken = refreshToken,
                RefreshTokenExpiration = refreshTokenExpiration
            };
        }

        public async Task<TokenResponsePackage> GenerateToken(UserEntity userEntity)
        {
            var accessTokenInfo = await GenerateAccessToken(userEntity);
            var refreshTokenInfo = await GenerateRefreshToken();
            return new TokenResponsePackage
            {
                AccessToken = accessTokenInfo.AccessToken,
                AccessTokenExpiration = accessTokenInfo.AccessTokenExpiration,
                RefreshToken = refreshTokenInfo.RefreshToken,
                RefreshTokenExpiration = refreshTokenInfo.RefreshTokenExpiration
            };
        }


        public async Task<int?> ValidateAccessToken(string token)
        {
            if (token == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtHelper.GetJwtParameter.Secret);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    RequireExpirationTime = true,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
                return userId;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }
    }
}