using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SGBYM.Domain.Interfaces;
using SGBYM.Domain.Models;
using SGBYM.Infrastructure.Data;

namespace SGBYM.Infrastructure
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;
        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateClient(Client cliente)
        {
            _context.clients.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClient(int id)
        {
            var client = await _context.clients.FindAsync(id);
            if (client != null) { 
                _context.clients.Remove(client);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Client>> GetAllClients()
        {
            return await _context.clients.ToListAsync();
        }

        public async Task<Client> GetById(int id)
        {
            return await _context.clients.FindAsync(id);
        }

        public async Task UpdateClient(Client cliente)
        {
            _context.clients.Update(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
