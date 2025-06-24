using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBYM.Application.DTOs.ClientDTO;
using SGBYM.Application.Interfaces;
using SGBYM.Application.Interfaces.security;
using SGBYM.Domain.Interfaces;
using SGBYM.Domain.Models;

namespace SGBYM.Application.Services
{
    public class ClientService : IClienteService
    {
        
        private readonly IClientRepository _clientRepository;
        private readonly IPassHasher _passHasher;
        public ClientService(IClientRepository clientRepository, IPassHasher passHasher)
        {
            _clientRepository = clientRepository;
            this._passHasher = passHasher;
        }

        public async Task CreateClient(CreateClientDTO client)
        {
            var cliente = new Client
            {
                Nombre = client.Nombre,
                Apellido = client.Apellido,
                Edad = (short)client.Edad,
                Telefono = client.Telefono,
                Correo = client.Correo,
                PasswordHash = _passHasher.HashPassword(client.PasswordHash)
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

        public async Task UpdateClient(UpdateClientDTO client)
        {
            var clienteExistente = await _clientRepository.GetById(client.IdCliente);
            if (clienteExistente == null)
                throw new Exception("Cliente no encontrado");
            clienteExistente.IdCliente = client.IdCliente;
            clienteExistente.Nombre = client.Nombre;
            clienteExistente.Apellido = client.Apellido;
            clienteExistente.Correo = client.Correo;
            clienteExistente.Telefono = client.Telefono;

            await _clientRepository.UpdateClient(clienteExistente);
        }
    }
}
