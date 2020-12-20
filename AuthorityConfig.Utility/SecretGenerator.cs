using System;
using System.Security.Cryptography;
using System.Text;

namespace AuthorityConfig.Utility
{
    public static class SecretGenerator
    {
        public static string GenerateSecret(int length = 32)
        {
            length = (length < 16) ? 16 : length;
            var bytes = new byte[length];
            using var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }

        public static string Sha256(this string secret)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(secret);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public static (string plain, string hash) GenerateSharedSecret(int length = 32)
        {
            var secret = GenerateSecret(length);
            return (secret, secret.Sha256());
        }

    }

}
