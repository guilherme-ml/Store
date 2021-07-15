using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    [ApiController]
    [Route("v1/Caracteristica")]
    public class CaracteristicaController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Caracteristica>>> Get([FromServices] DataContext context)
        {
            var caracteristica = await context.Caracteristica.ToListAsync();
            return caracteristica;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Caracteristica>> Post(
            [FromServices] DataContext context,
            [FromBody] Caracteristica model)
        {
            if (ModelState.IsValid)
            {
                context.Caracteristica.Add(model);
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
        public async Task<ActionResult<Caracteristica>> GetById([FromServices] DataContext context, int id)
        {
            var caracteristica = await context.Caracteristica
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return caracteristica;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Caracteristica>> Update(
            [FromServices] DataContext context,
            [FromBody] Caracteristica caracteristica,
            int id)
        {
            if (id != caracteristica.Id) { return BadRequest(); }
            context.Entry(caracteristica).State = EntityState.Modified;

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
