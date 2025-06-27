using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBYM.Domain.Models;

namespace SGBYM.Domain.Interfaces
{
    public interface IServiceProvidedRepository
    {
        Task<IEnumerable<ServiceProvided>> GetAllServices();
        Task<ServiceProvided> GetById(int id);
        Task CreateServices(ServiceProvided service);
        Task UpdateServices(ServiceProvided service);
        Task DeleteServices(int id);

    } 
}
