using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGBYM.Application.DTOs.ClientDTO;
using SGBYM.Application.DTOs.ServiceProvidedDTO;
using SGBYM.Application.Interfaces;
using SGBYM.Application.Services;

namespace SGBYM.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceProvidedController : ControllerBase
    {
        private readonly IServiceProvided _serviceProvided;
        public ServiceProvidedController(IServiceProvided serviceProvided)
        {
            this._serviceProvided = serviceProvided;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _serviceProvided.GetAllServices());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _serviceProvided.GetById(id));

        [HttpPost]
        public async Task<IActionResult> create([FromBody] ServiceProvidedCreateDTO serviceProvided)
        {
            await _serviceProvided.CreateServices(serviceProvided);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> update([FromBody] ServiceProvidedUpdateDTO serviceProvided)
        {
            await _serviceProvided.UpdateServices(serviceProvided);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> delete(int id)
        {
            await _serviceProvided.DeleteServices(id);
            return Ok();
        }
    }
}
