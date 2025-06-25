using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBYM.Application.DTOs.AdminitratorDTO;

namespace SGBYM.Application.Interfaces
{
    public interface IAdminService
    {
        Task<IEnumerable<AdminSummDTO>> GetAllAdmins();
        Task<AdminSummDTO> GetById(int id);
        Task CreateAdmin(AdminCreateDTO admin);
        Task UpdateAdmin(UpdateClienteDTO admin);
        Task DeleteAdmin(int id);

    }
}
