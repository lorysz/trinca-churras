using Microsoft.AspNetCore.Mvc;
using TrincaChurras.Application.DTO;
using TrincaChurras.Application.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrincaChurras.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        protected readonly IPersonApplication _personApplication;

        public PersonController(IPersonApplication personApplication)
        {
            _personApplication = personApplication;
        }

        // GET: api/<PersonController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _personApplication.BuscarTodos();

            return Ok(result);
        }

        // POST api/<PersonController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserDTO value)
        {
            await _personApplication.Cadastrar(value);

            return Ok(true);
        }
    }
}
