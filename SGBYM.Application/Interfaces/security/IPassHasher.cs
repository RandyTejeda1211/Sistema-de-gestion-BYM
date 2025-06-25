using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBYM.Application.Interfaces.security
{
    public interface IPassHasher
    {
        byte[] HashPassword(string password);
        bool VerifyPassword(string password, byte[] passwordHash);
    }
}
