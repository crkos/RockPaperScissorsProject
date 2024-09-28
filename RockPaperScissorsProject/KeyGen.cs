using System.Security.Cryptography;

namespace RockPaperScissorsProject
{
    internal class KeyGen
    {
        public static string GenerateRandomKey()
        {
            byte[] key = new byte[32]; // 256 bits
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            rng.GetBytes(key);
            return Convert.ToHexString(key);
        }
    }
}
