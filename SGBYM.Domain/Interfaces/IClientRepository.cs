using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBYM.Domain.Models;

namespace SGBYM.Domain.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllClients();
        Task<Client> GetById(int id);
        Task CreateClient(Client client);
        Task UpdateClient(Client client);
        Task DeleteClient(int id);
    }
}
