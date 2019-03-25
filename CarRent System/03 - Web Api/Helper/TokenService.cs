using CarRent.Helper;
using System;

namespace CarRent
{

    /// <summary>
    /// This class create a token, of time, name adn role.
    /// </summary>
    public class TokenService
    {
        private static string dateTimeFormat = "dd/MM/yyyy HH:mm";
        //Token life:
        private static int tokenLifeTime = 15;

        
        public static string GenerateToken(TokenModel token)
        {
            return Encryptor.Encrypt(token.id + "#" + token.userName + "#" + token.role + "#" + DateTime.Now.ToString(dateTimeFormat));
        }

        public static TokenModel ValidateToken(string token)
        {
 
            string decryptedAuthenticationToken = Encryptor.Decrypt(token);
            string[] credentialsArray = decryptedAuthenticationToken.Split('#');
            // decrypt token 
            int id = Convert.ToInt32(credentialsArray[0]);
            string userName = credentialsArray[1];
            string role = credentialsArray[2];
            DateTime date = DateTime.ParseExact(credentialsArray[3],
                            dateTimeFormat,
                            System.Globalization.CultureInfo.InstalledUICulture);
            if (date.AddMinutes(tokenLifeTime) < DateTime.Now)
            {
                throw new Exception("Token expired");
            }
            return new TokenModel { id = id, role = role, userName = userName };
        }
    }
}
