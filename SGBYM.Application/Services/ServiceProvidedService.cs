using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBYM.Application.DTOs.ClientDTO;
using SGBYM.Application.DTOs.ServiceProvidedDTO;
using SGBYM.Application.Interfaces;
using SGBYM.Domain.Interfaces;
using SGBYM.Domain.Models;

namespace SGBYM.Application.Services
{
    public class ServiceProvidedService : IServiceProvided
    {

        private readonly IServiceProvidedRepository _serviceProvided;

        public ServiceProvidedService(IServiceProvidedRepository serviceProvided)
        {
            _serviceProvided = serviceProvided;
        }
        public async Task CreateServices(ServiceProvidedCreateDTO service)
        {
            var serviceProvided = new ServiceProvided
            {
                nombre = service.nombre,
                precio = service.precio,
                caracteristica = service.caracteristicas,
            };
            await _serviceProvided.CreateServices(serviceProvided);
        }

        public async Task DeleteServices(int id)
        {
            await _serviceProvided.DeleteServices(id);
        }

        public async Task<IEnumerable<ServiceProvidedSummDTO>> GetAllServices()
        {
            var service = await _serviceProvided.GetAllServices();
            return service.Select(s => new ServiceProvidedSummDTO { 
                nombre = s.nombre,
                precio = s.precio,
                caracteristicas = s.caracteristica
            });
        }

        public async Task<ServiceProvidedSummDTO> GetById(int id)
        {
            var service = await _serviceProvided.GetById(id);
            return new ServiceProvidedSummDTO
            {
                nombre = service.nombre,
                precio = service.precio,
                caracteristicas = service.caracteristica,
            };
        }

        public async Task UpdateServices(ServiceProvidedUpdateDTO service)
        {
            var ServiceExistente = await _serviceProvided.GetById(service.idServicio);
            if (ServiceExistente == null)
                throw new Exception("Servicio no encontrado");

            ServiceExistente.nombre = service.nombre;
            ServiceExistente.precio = service.precio;
            ServiceExistente.caracteristica = service.caracteristicas;
            
            await _serviceProvided.UpdateServices(ServiceExistente);
        }
    }
}
