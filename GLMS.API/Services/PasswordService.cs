using System.Security.Cryptography;
using System.Text;

namespace GLMS.API.Services
{
    public class PasswordService
    {
        public string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        public bool VerifyPassword(string password, string hash)
        {
            return HashPassword(password) == hash;
        }
    }
}
