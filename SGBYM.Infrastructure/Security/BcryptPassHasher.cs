using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBYM.Application.Interfaces.security;
using BCrypt.Net;

namespace SGBYM.Infrastructure.Security
{
    public class BcryptPassHasher : IPassHasher
    {
        public byte[] HashPassword(string password)
        {
            var hashed = BCrypt.Net.BCrypt.HashPassword(password);
            return Encoding.UTF8.GetBytes(hashed);
        }

        public bool VerifyPassword(string password, byte[] passwordHash)
        {
            var hashedPassword = System.Text.Encoding.UTF8.GetString(passwordHash);
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
