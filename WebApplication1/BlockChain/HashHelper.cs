using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication1.BlockChain
{
    public static class HashHelper
    {
        public static string Hash(string input)
        {
            return HashInternal(input);
        }

        private static string HashInternal(string str)
        {
            using (var sha = SHA256.Create())
            {
                var inputBytes = Encoding.UTF8.GetBytes(str);
                var hashBytes = sha.ComputeHash(inputBytes);
                return GetStringFromHash(hashBytes);
            }
        }

        private static string GetStringFromHash(IEnumerable<byte> hash)
        {
            var result = new StringBuilder();
            foreach (var h in hash)
            {
                result.Append(h.ToString("X2"));
            }

            return result.ToString();
        }
    }
}
