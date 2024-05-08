using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Investigacion.API.Data;
using Investigacion.Shared.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Investigacion.API.Controllers
{
    [ApiController]
    [Route("api/Investigadores")]
    public class InvestigadoresController : ControllerBase
    {
        private readonly DataContext _context;

        public InvestigadoresController(DataContext context)
        {
            _context = context;
        }

        // GET: /api/Investigadores
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            
            return Ok(await _context.Investigadores.ToListAsync());
        }

        // GET: /api/Investigadores/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var investigador = await _context.Investigadores.FirstOrDefaultAsync(x => x.Id == id);
            if (investigador == null)
            {
                return NotFound();
            }
            return Ok(investigador);
        }

        // POST: /api/Investigadores
        [HttpPost]
        public async Task<ActionResult> Post(Investigador investigador)
        {
                _context.Add(investigador);
                await _context.SaveChangesAsync();
                return Ok(investigador);    

        }

        // PUT: /api/Investigadores/5
        [HttpPut]
        public async Task<ActionResult> Put (Investigador investigador )
        {
            _context.Investigadores.Update(investigador);

            await _context.SaveChangesAsync();

            return Ok(investigador);
        }

        // DELETE: /api/Investigadores/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filasafectadas = await _context.Investigadores
               .Where(x => x.Id == id)
               .ExecuteDeleteAsync();

            if (filasafectadas == 0)
            {


                return NotFound();  //404
            }

            return NoContent();//204
        }

    }
}
