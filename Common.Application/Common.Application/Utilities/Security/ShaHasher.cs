using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common.Application.Utilities.Security
{
    public class ShaHasher
    {
        public static string Hash(string inputValue)
        {
            using var sha256 = SHA256.Create();
            var originalBytes = Encoding.Default.GetBytes(inputValue);
            var encodedBytes = sha256.ComputeHash(originalBytes);
            return Convert.ToBase64String(encodedBytes);
        }
        public static bool IsEqual(string hashText, string rawText)
        {
            var hash = Hash(rawText);
            return hashText == hash;
        }
    }
}
