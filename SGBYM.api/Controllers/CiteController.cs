using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGBYM.Application.DTOs.CiteDTO;
using SGBYM.Application.Interfaces;

namespace SGBYM.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiteController : ControllerBase
    {
        private readonly ICiteService _citeService;
        public CiteController(ICiteService citeService)
        {
            _citeService = citeService;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CiteCreateDTO citeCreate)
        {
            await _citeService.CreateCite(citeCreate);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _citeService.GetAllCite());
    }
}
