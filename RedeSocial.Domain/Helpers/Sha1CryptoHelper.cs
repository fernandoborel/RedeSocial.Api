using System.Security.Cryptography;
using System.Text;

namespace RedeSocial.Domain.Helpers
{
    /// <summary>
    /// Classe para criptografia de dados padrão SHA1
    /// </summary>
    public static class Sha1CryptoHelper
    {
        public static string Create(string input)
        {
            using (var sha1 = SHA1.Create())
            {
                var inputBytes = Encoding.UTF8.GetBytes(input);
                var hashBytes = sha1.ComputeHash(inputBytes);

                var builder = new StringBuilder();

                foreach (var b in hashBytes)
                    builder.Append(b.ToString("x2"));

                return builder.ToString();
            }
        }
    }
}