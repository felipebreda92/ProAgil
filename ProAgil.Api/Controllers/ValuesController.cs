using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProAgil.Api.Contexts;
using ProAgil.Api.Models;

namespace ProAgil.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _context.Evento.ToListAsync();

                if(results == null)
                    return NoContent();

                return Ok(results);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao encontrar os eventos.\n Erro: {e.Message}");
            }

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if(id == 0)
                    return BadRequest($"Informe um {nameof(id)} válido.");

                var result = await _context.Evento.FirstOrDefaultAsync(x => x.IdEvento == id);
                if(result == null)
                    return NoContent();

                return Ok(result);
            }
            catch (System.Exception e)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao encontrar os eventos.\n Erro: {e.Message}");
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
