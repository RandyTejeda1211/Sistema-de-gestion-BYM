using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBYM.Application.DTOs.ServiceProvidedDTO;
using SGBYM.Domain.Models;

namespace SGBYM.Application.Interfaces
{
    public interface IServiceProvided
    {
        Task<IEnumerable<ServiceProvidedSummDTO>> GetAllServices();
        Task<ServiceProvidedSummDTO> GetById(int id);
        Task CreateServices(ServiceProvidedCreateDTO service);
        Task UpdateServices(ServiceProvidedUpdateDTO service);
        Task DeleteServices(int id);
    }
}
