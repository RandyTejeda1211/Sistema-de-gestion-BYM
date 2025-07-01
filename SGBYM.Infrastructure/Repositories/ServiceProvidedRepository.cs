using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SGBYM.Domain.Interfaces;
using SGBYM.Domain.Models;
using SGBYM.Infrastructure.Data;

namespace SGBYM.Infrastructure.Repositories
{
    public class ServiceProvidedRepository : IServiceProvidedRepository
    {
        private readonly AppDbContext _context;
        public ServiceProvidedRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateServices(ServiceProvided service)
        {
            _context.serviceProvided.Add(service);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteServices(int id)
        {
            var service = await _context.serviceProvided.FindAsync(id);
            if(service != null)
            {
                _context.Remove(service);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ServiceProvided>> GetAllServices()
        {
            return await _context.serviceProvided.ToListAsync();
        }

        public async Task<ServiceProvided> GetById(int id)
        {
            return await _context.serviceProvided.FindAsync(id);
        }

        public async Task UpdateServices(ServiceProvided service)
        {
            _context.serviceProvided.Update(service);
            await _context.SaveChangesAsync();
        }
    }
}
