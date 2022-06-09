using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace MultiCoreApp.DataAccessLayer.Security
{
    public static class SignHandler // Handler lar static olarak eklenir.
    {
        public static SecurityKey GetSymmetricSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)); // Burada şifreleme işlemi yapılıyor.
        }
    }
}
