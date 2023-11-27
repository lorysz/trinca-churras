using Microsoft.AspNetCore.Mvc;
using TrincaChurras.Application.DTO;
using TrincaChurras.Application.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrincaChurras.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChurrrasController : ControllerBase
    {
        protected readonly IChurrasApplication _churrasApplication;

        public ChurrrasController(IChurrasApplication churrasApplication)
        {
            _churrasApplication = churrasApplication;
        }

        // GET api/<ChurrrasController>/5
        [HttpGet("BuscarChurrasComAval")]
        public async Task<IActionResult> BuscarChurrasComAval()
        {
            var result = await _churrasApplication.BuscarChurrasComAval();
            return Ok(result);
        }

        // GET api/<ChurrrasController>/5
        [HttpGet("BuscarChurrasSemAval")]
        public async Task<IActionResult> BuscarChurrasSemAval()
        {
            var result = await _churrasApplication.BuscarChurrasSemAval();
            return Ok(result);
        }

        // POST api/<ChurrrasController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateChurrasDTO value)
        {
            await _churrasApplication.Cadastrar(value);
            return Ok(true);
        }

        // PUT api/<ChurrrasController>/5
        [HttpPut("ConfirmarAval/{id}")]
        public async Task<IActionResult> ConfirmarAval(string id)
        {
            await _churrasApplication.ConfirmarAval(id);
            return Ok(true);
        }

        // PUT api/<ChurrrasController>/5
        [HttpPost("AceitarConvite/{id}")]
        public async Task<IActionResult> AceitarConvite(string id, [FromBody] string idUser)
        {
            await _churrasApplication.AceitarConvite(id, idUser);
            return Ok(true);
        }

        // PUT api/<ChurrrasController>/5
        [HttpPost("RejeitarConvite/{id}")]
        public async Task<IActionResult> RejeitarConvite(string id, [FromBody] string idUser)
        {
            await _churrasApplication.RejeitarConvite(id, idUser);
            return Ok(true);
        }
    }
}
