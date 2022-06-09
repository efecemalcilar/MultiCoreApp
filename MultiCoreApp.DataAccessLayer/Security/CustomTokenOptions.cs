namespace MultiCoreApp.DataAccessLayer.Security
{
    public class CustomTokenOptions
    {
        public string Audience { get; set; } // Burada nereyi dinleyeceğimi söylüyorum. İsteğin bana geleceği yeri dinleyeceğim.

        public string Issuer { get; set; } // Burada işlemi yürütücem

        public int AccessTokenExpiration { get; set; }
        
        public int RefreshTokenExpiration { get; set; }

        public string SecurityKey { get; set; }

        
        
        






    }
}
