using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Investigacion.API.Data;
using Investigacion.Shared.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Investigacion.API.Controllers
{
    [ApiController]
    [Route("api/Proyectos")]
    public class ProyectosController : ControllerBase
    {
        private readonly DataContext _context;

        public ProyectosController(DataContext context)
        {
            _context = context;
        }

        // GET: /api/Proyectos
        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Proyectos.ToListAsync());
        }

        // GET: /api/Proyectos/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var proyecto = await _context.Proyectos.FirstOrDefaultAsync(x => x.Id == id);
            if (proyecto == null)
            {
                return NotFound();
            }
            return Ok(proyecto);
        }

        // POST: /api/Proyectos
        [HttpPost]
        public async Task<ActionResult> Post(Proyecto proyecto)
        {

            {
                _context.Add(proyecto);
                await _context.SaveChangesAsync();
                return Ok(proyecto);
            }

        }

        // PUT: /api/Proyectos/5
        [HttpPut]
        public async Task<ActionResult> Put(Proyecto proyecto)
        {

            {
                _context.Update(proyecto);
                return Ok(proyecto);
            }

        }

        // DELETE: /api/Proyectos/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filasAfectadas = await _context.Proyectos
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
