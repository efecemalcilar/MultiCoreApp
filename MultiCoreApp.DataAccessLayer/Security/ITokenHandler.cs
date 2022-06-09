using MultiCoreApp.Core.Models;

using MultiCoreApp.DataAccessLayer.Security;

namespace MultiCoreApp.DataAccessLayer.Security
{
    public interface ITokenHandler
    {
        AccessToken CreateAccessToken(User user);

        void RevokeRefreshToken(User user); //RevokeRefreshToken kullanıcı logout olduktan sonra token silinsin ki biri gelip token ı ele geçirirse sıkıntı yaşamayalım.

        
        
        
    }
}
