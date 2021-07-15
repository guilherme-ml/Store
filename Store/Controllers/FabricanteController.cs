using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    [ApiController]
    [Route("v1/Fabricante")]
    public class FabricanteController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Fabricante>>> Get([FromServices] DataContext context)
        {
            var fabricante = await context.Fabricantes.ToListAsync();
            return fabricante;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Fabricante>> Post(
            [FromServices] DataContext context,
            [FromBody] Fabricante model)
        {
            if (ModelState.IsValid)
            {
                context.Fabricantes.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Fabricante>> GetById([FromServices] DataContext context, int id)
        {
            var fabricante = await context.Fabricantes
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return fabricante;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Fabricante>> Update(
            [FromServices] DataContext context,
            [FromBody] Fabricante fabricante,
            int id)
        {
            if (id != fabricante.Id) { return BadRequest(); }
            context.Entry(fabricante).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}

