using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBYM.Domain.Models;

namespace SGBYM.Domain.Interfaces
{
    public interface IAdminRepository
    {
        Task<IEnumerable<Administrator>> GetAllAdmins();
        Task<Administrator> GetById(int id);
        Task CreateAdmin(Administrator admin);
        Task UpdateAdmin(Administrator admin);
        Task DeleteAdmin(int id);
    }
}
