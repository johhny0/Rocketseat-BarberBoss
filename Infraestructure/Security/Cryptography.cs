using BC = BCrypt.Net.BCrypt;
using Domain.Security.Cryptography;

namespace Infraestructure.Security
{
    public class Cryptography : IPasswordEncripter
    {
        public string Encrypt(string password)
        {
            return BC.HashPassword(password);
        }

        public bool Verify(string password, string passwordHash)
        {
            return BC.Verify(password, passwordHash);
        }
    }
}
