using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SGBYM.Domain.Interfaces;
using SGBYM.Domain.Models;
using SGBYM.Infrastructure.Data;

namespace SGBYM.Infrastructure.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AppDbContext _context;
        public LoginRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<UserCredentials?> GetByEmailAsync(string correo)
        {
            var user = await _context.clients
                .FirstOrDefaultAsync(c => c.Correo == correo);

            if (user == null)
                return null;

            

            return new UserCredentials
            {
                IdCliente = user.IdCliente,
                Correo = user.Correo,
                PasswordHash = user.PasswordHash
            };

        }
    }
}
