using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{

    [ApiController]
    [Route("v1/Itemcompra")]
    public class ItemCompraController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<ItemCompra>>> Get([FromServices] DataContext context)
        {
            var itemCompra = await context.ItemCompra.ToListAsync();
            return itemCompra;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<ItemCompra>> Post(
            [FromServices] DataContext context,
            [FromBody] ItemCompra model)
        {
            if (ModelState.IsValid)
            {
                context.ItemCompra.Add(model);
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
        public async Task<ActionResult<ItemCompra>> GetById([FromServices] DataContext context, int id)
        {
            var itemCompra = await context.ItemCompra
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return itemCompra;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ItemCompra>> Update(
            [FromServices] DataContext context,
            [FromBody] ItemCompra itemCompra,
            int id)
        {
            if (id != itemCompra.Id) { return BadRequest(); }
            context.Entry(itemCompra).State = EntityState.Modified;

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
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ItemCompra>> Delete(
        [FromServices] DataContext context,
        int id)
        {
            var itemCompra = await context.ItemCompra.FindAsync(id);
            context.ItemCompra.Remove(itemCompra);
            await context.SaveChangesAsync();
            return itemCompra;
        }
    }
}
