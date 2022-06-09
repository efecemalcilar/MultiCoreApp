using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MultiCoreApp.Core.IntService;
using MultiCoreApp.Core.Models;

namespace MultiCoreApp.DataAccessLayer.Security
{
    public class TokenHandler:ITokenHandler
    {
        private readonly CustomTokenOptions _tokenOptions;

        public TokenHandler(IOptions<CustomTokenOptions> tokenOptions)
        {
            _tokenOptions = tokenOptions.Value;
        }
        public AccessToken CreateAccessToken(User user)
        {
            var accesstokenExpriation = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);

            var securityKey = SignHandler.GetSymmetricSecurityKey(_tokenOptions.SecurityKey);

            SigningCredentials  signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            JwtSecurityToken jtwSecurityToken = new JwtSecurityToken(


                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                expires: accesstokenExpriation,
                notBefore: DateTime.Now, // Sureli kampanyaları buradan suresini ayarlabiliyoruz.
                claims: GetClaims(user),
                signingCredentials: signingCredentials

            );
            var handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(jtwSecurityToken);
            AccessToken accessToken = new AccessToken();
            accessToken.Token = token;
            accessToken.RefreshToken = CreateRefreshToken();
            accessToken.Expiration = accesstokenExpriation;


            return accessToken;

        }

        private string CreateRefreshToken()
        {
            //AccessToken olusturuldugunda refreshtoken da olusturulmasi gerektiğinden olusturulma islemini bu methodun icinde yapmamız gerekiyor. olusturulacak token sistemde kullanılan sifreleme sistemi ile aynı anda 
            var numberByte = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(numberByte);
                return Convert.ToBase64String(numberByte);
            }
        }
        private IEnumerable<Claim> GetClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(ClaimTypes.Name,$"{user.Name} {user.Surname}"),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())


            };
            return claims;
        }
        
        public void RevokeRefreshToken(User user)
        {
            user.RefreshToken = null;
        }

        

        
    }
}
