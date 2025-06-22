using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBYM.Application.DTOs;
using SGBYM.Application.Interfaces;
using SGBYM.Domain.Interfaces;
using SGBYM.Domain.Models;

namespace SGBYM.Application.Services
{
    public class ClientService : IClienteService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task CreateClient(CreateClientDTO client)
        {
            var cliente = new Client
            {
                IdCliente = client.Id,
                Nombre = client.Nombre,
                Apellido = client.Apellido,
                Edad = (short)client.Edad,
                Telefono = client.Telefono,
                Correo = client.Correo
            };
            await _clientRepository.CreateClient(cliente);
        }

        public async Task DeleteClient(int id)
        {
            await _clientRepository.DeleteClient(id);
        }

        public async Task<IEnumerable<ClientSummDTO>> GetAllClient()
        {
            var client = await _clientRepository.GetAllClients();
            return client.Select(c => new ClientSummDTO
            {
                Id = c.IdCliente,
                Nombre = c.Nombre,
                Apellido = c.Apellido,
                Correo = c.Correo,
            });
        }

        public async Task<ClientSummDTO> GetById(int id)
        {
            var client = await _clientRepository.GetById(id);
            return new ClientSummDTO
            {
                Id = client.IdCliente,
                Nombre = client.Nombre,
                Apellido = client.Apellido,
                Correo = client.Correo,
            };
        }

        public async Task UpdateClient(ClientSummDTO client)
        {
            var cliente = new Client
            {
                IdCliente = client.Id,
                Nombre = client.Nombre,
                Apellido = client.Apellido,
                Correo = client.Correo
            };
            await _clientRepository.UpdateClient(cliente);
        }
    }
}
