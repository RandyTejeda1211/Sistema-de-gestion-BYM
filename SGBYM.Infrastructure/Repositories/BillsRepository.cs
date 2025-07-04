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
    public class BillsRepository : IBillRepository
    {
        private readonly AppDbContext _context;
        public BillsRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task createBills(Bills bills)
        {
            _context.bills.Add(bills);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Bills>> GetAllBill()
        {
            return await _context.bills.ToListAsync();
        }

        public async Task<Bills> getBySerial(string serial)
        {
            return await _context.bills.FindAsync(serial);


        }


    }
}
