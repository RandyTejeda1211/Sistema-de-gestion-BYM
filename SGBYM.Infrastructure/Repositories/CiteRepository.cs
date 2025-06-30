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
    public class CiteRepository : ICiteRepository
    {

        private readonly AppDbContext _appDbContext;
        public CiteRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task CreateCita(Cite cite)
        {
            _appDbContext.cites.Add(cite);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteCita(int id)
        {
            var cite = await _appDbContext.cites.FindAsync(id);
            if(cite != null)
            {
                _appDbContext.cites.Remove(cite);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Cite>> GetAllCites()
        {
            return await _appDbContext.cites.ToListAsync();
        }

        public async Task<Cite> GetById(int id)
        {
            return await _appDbContext.cites.FindAsync(id);
        }

        public async Task UpdateCita(Cite cite)
        {
            _appDbContext.cites.Update(cite);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
