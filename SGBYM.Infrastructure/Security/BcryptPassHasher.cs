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
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
            
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
