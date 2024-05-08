using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Investigacion.API.Data;
using Investigacion.Shared.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Investigacion.API.Controllers
{
    [ApiController]
    [Route("api/Actividades")]
    public class ActividadesInvestigacionController : ControllerBase
    {
        private readonly DataContext _context;

        public ActividadesInvestigacionController(DataContext context)
        {
            _context = context;
        }

        // GET: /api/Actividades
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            
            return Ok(await _context.ActividadesInvestigacion.ToListAsync());
        }

        // GET: /api/Actividades/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var actividadInvestigacion = await _context.ActividadesInvestigacion.FirstOrDefaultAsync(x => x.Id == id);
            if (actividadInvestigacion == null)
            {
                return NotFound();
            }
            return Ok(actividadInvestigacion);
        }

        // POST: /api/Actividades
        [HttpPost]
        public async Task<ActionResult> Post(ActividadInvestigacion actividadInvestigacion)
        {
            
            {
                _context.Add(actividadInvestigacion);
                await _context.SaveChangesAsync();
                return Ok(actividadInvestigacion);
            }
           
        }

        // PUT: /api/Actividades/5
        [HttpPut]
        public async Task<ActionResult> Put(ActividadInvestigacion actividadInvestigacion)
        {

            { 
                _context.ActividadesInvestigacion.Update(actividadInvestigacion);

                await _context.SaveChangesAsync();

                return Ok(actividadInvestigacion);
            }

        }

        // DELETE: /api/Actividades/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filasAfectadas = await _context.ActividadesInvestigacion
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
