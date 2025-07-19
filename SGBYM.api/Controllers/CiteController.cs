using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGBYM.Application.DTOs;
using SGBYM.Application.DTOs.BillsDTO;
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
        public async Task<IActionResult> Create([FromBody] CiteBillCreateDTO citeBillCreate)
        {
            await _citeService.CreateCite(citeBillCreate);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _citeService.GetAllCite());
        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CiteUpdateDTO citeUpdate)
        {
            await _citeService.UpdateCite(citeUpdate);
            return Ok();
        }
    }
}
