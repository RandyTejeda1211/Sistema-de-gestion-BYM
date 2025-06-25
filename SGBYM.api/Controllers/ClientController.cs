using Microsoft.AspNetCore.Mvc;
using SGBYM.Application.DTOs.ClientDTO;
using SGBYM.Application.Interfaces;

namespace SGBYM.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientController(IClienteService clienteService) { 
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> getAll() => Ok(await _clienteService.GetAllClient());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _clienteService.GetById(id));

        [HttpPost]
        public async Task<IActionResult> create([FromBody] CreateClientDTO createClientDTO)
        {
            await _clienteService.CreateClient(createClientDTO);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateClientDTO updateClientDTO)
        {
            await _clienteService.UpdateClient(updateClientDTO);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _clienteService.DeleteClient(id);
            return Ok();
        }
    }
}
