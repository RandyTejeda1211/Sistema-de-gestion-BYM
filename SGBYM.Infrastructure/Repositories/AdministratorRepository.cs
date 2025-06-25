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
    public class AdministratorRepository : IAdminRepository
    {
        private readonly AppDbContext _context;
        public AdministratorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAdmin(Administrator admin)
        {
            _context.administrators.Add(admin);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAdmin(int id)
        {
            var admins = _context.administrators.FindAsync(id);
            if (admins != null)
            {
                _context.administrators.Remove(await admins);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Administrator>> GetAllAdmins()
        {
            return await _context.administrators.ToListAsync();
        }

        public async Task<Administrator> GetById(int id)
        {
            return await _context.administrators.FindAsync(id);
        }

        public async Task UpdateAdmin(Administrator admin)
        {
           _context.administrators.Update(admin);
            await _context.SaveChangesAsync();
        }
    }
}
