using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Investigacion.API.Data;
using Investigacion.Shared.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Investigacion.API.Controllers
{
    [ApiController]
    [Route("api/RecursosEspecializados")]
    public class RecursosEspecializadosController : ControllerBase
    {
        private readonly DataContext _context;

        public RecursosEspecializadosController(DataContext context)
        {
            _context = context;
        }

        // GET: /api/RecursosEspecializados
        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.RecursosEspecializados.ToListAsync());
        }

        // GET: /api/RecursosEspecializados/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var recursoEspecializado = await _context.RecursosEspecializados.FirstOrDefaultAsync(x => x.Id == id);
            if (recursoEspecializado == null)
            {
                return NotFound();
            }

    
            return Ok(recursoEspecializado);
        }

        // POST: /api/RecursosEspecializados
        [HttpPost]
        public async Task<ActionResult> Post(RecursoEspecializado recursoEspecializado)
        {

            {
                _context.Add(recursoEspecializado);
                await _context.SaveChangesAsync();
                return Ok(recursoEspecializado);
            }

        }

        // PUT: /api/RecursosEspecializados/5
        [HttpPut]
        public async Task<ActionResult> Put(RecursoEspecializado recursoEspecializado)
        {

            {
                _context.RecursosEspecializados.Update(recursoEspecializado);
                await _context.SaveChangesAsync();
                return Ok(recursoEspecializado);
            }

        }

        // DELETE: /api/RecursosEspecializados/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filasAfectadas = await _context.RecursosEspecializados
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();
            if (filasAfectadas == 0)
            {
                return NotFound();
            }


            return NoContent();
        }
    }
}
