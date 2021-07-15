using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    [ApiController]
    [Route("v1/Compra")]
    public class CompraController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Compra>>> Get([FromServices] DataContext context)
        {
            var compra = await context.Compra.ToListAsync();
            return compra;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Compra>> Post(
            [FromServices] DataContext context,
            [FromBody] Compra model)
        {
            if (ModelState.IsValid)
            {
                context.Compra.Add(model);
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
        public async Task<ActionResult<Compra>> GetById([FromServices] DataContext context, int id)
        {
            var compra = await context.Compra
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return compra;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Compra>> Update(
            [FromServices] DataContext context,
            [FromBody] Compra compra,
            int id)
        {
            if (id != compra.Id) { return BadRequest(); }
            context.Entry(compra).State = EntityState.Modified;

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
