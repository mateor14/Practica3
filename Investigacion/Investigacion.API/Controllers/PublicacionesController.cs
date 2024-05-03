using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Investigacion.API.Data;
using Investigacion.Shared.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Investigacion.API.Controllers
{
    [ApiController]
    [Route("api/Publicaciones")]
    public class PublicacionesController : ControllerBase
    {
        private readonly DataContext _context;

        public PublicacionesController(DataContext context)
        {
            _context = context;
        }

        // GET: /api/Publicaciones
        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Publicaciones.ToListAsync());
        }

        // GET: /api/Publicaciones/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var publicacion = await _context.Publicaciones.FirstOrDefaultAsync(x => x.Id == id);
            if (publicacion == null)
            {
                return NotFound();
            }
            return Ok(publicacion);
        }

        // POST: /api/Publicaciones
        [HttpPost]
        public async Task<ActionResult> Post(Publicacion publicacion)
        {

            {
                _context.Add(publicacion);
                await _context.SaveChangesAsync();
                return Ok(publicacion);
            }

        }

        // PUT: /api/Publicaciones/5
        [HttpPut]
        public async Task<ActionResult> Put(Publicacion publicacion)
        {

            {
                _context.Update(publicacion);
                return Ok(publicacion);
            }

        }
        // DELETE: /api/Publicaciones/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filasAfectadas = await _context.Publicaciones
                .Where(x => x.ID_Proyecto == id)
                .ExecuteDeleteAsync();
            if (filasAfectadas == 0)
            {
                return NotFound();
            }


            return NoContent();
        }

      
    }
}
