using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBYM.Domain.Models;

namespace SGBYM.Domain.Interfaces
{
    public interface ILoginRepository
    {
        public Task<UserCredentials?> GetByEmailAsync(string correo);
    }
}
