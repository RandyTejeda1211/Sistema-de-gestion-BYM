using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBYM.Application.DTOs.ClientDTO;

namespace SGBYM.Application.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClientSummDTO>> GetAllClient();
        Task<ClientSummDTO> GetById(int id);
        Task CreateClient(CreateClientDTO client);
        Task UpdateClient(UpdateClientDTO client);
        Task DeleteClient(int id);
    }
}
