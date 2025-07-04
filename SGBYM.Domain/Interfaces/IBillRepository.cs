using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBYM.Domain.Models;

namespace SGBYM.Domain.Interfaces
{
    public interface IBillRepository
    {
        Task<IEnumerable<Bills>> GetAllBill();
        Task<Bills> getBySerial(string serial);
        Task createBills(Bills bills);
    }
}
