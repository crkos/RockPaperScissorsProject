using System.Security.Cryptography;
using System.Text;

namespace RockPaperScissorsProject
{
    internal class HmacUtil
    {
        public static string ComputeHmac(string message, string key)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);

            using HMACSHA256 hmac = new(keyBytes);
            byte[] hash = hmac.ComputeHash(messageBytes);


            return Convert.ToHexString(hash);
        }
    }
}
