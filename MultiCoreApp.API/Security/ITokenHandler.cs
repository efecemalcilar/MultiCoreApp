using MultiCoreApp.Core.Models;

namespace MultiCoreApp.API.Security
{
    public interface ITokenHandler
    {
        AccessToken CreateAccessToken(User user);

        void RevokeRefreshToken(User user); //RevokeRefreshToken kullanıcı logout olduktan sonra token silinsin ki biri gelip token ı ele geçirirse sıkıntı yaşamayalım.

        
        
        
    }
}
