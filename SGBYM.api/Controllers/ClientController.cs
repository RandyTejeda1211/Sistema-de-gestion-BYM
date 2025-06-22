using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
