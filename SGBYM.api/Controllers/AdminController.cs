using Microsoft.AspNetCore.Mvc;
using SGBYM.Application.DTOs.AdminitratorDTO;
using SGBYM.Application.Interfaces;

namespace SGBYM.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public async Task<IActionResult> getAll() => Ok(await _adminService.GetAllAdmins());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _adminService.GetById(id));

        [HttpPost]
        public async Task<IActionResult> create([FromBody] AdminCreateDTO adminCreateDTO)
        {
            await _adminService.CreateAdmin(adminCreateDTO);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateClienteDTO updateAdminDTO)
        {
            await _adminService.UpdateAdmin(updateAdminDTO);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            await _adminService.DeleteAdmin(id);
            return Ok();
        }
    }
}
