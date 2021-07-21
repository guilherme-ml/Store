using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    [ApiController]
    [Route("v1/Cliente")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Cliente>>> Get([FromServices] DataContext context)
        {
            var cliente = await context.Clientes.ToListAsync();
            return cliente;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Cliente>> Post(
            [FromServices] DataContext context,
            [FromBody] Cliente model)
        {
            if (ModelState.IsValid)
            {
                context.Clientes.Add(model);
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
        public async Task<ActionResult<Cliente>> GetById([FromServices] DataContext context, int id)
        {
            var cliente = await context.Clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return cliente;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Cliente>> Update(
            [FromServices] DataContext context,
            [FromBody] Cliente cliente,
            int id)
        {
            if (id != cliente.Id) { return BadRequest(); }
            context.Entry(cliente).State = EntityState.Modified;

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
        public async Task<ActionResult<Cliente>> Delete(
        [FromServices] DataContext context,
        int id)
        {
            var cliente = await context.Clientes.FindAsync(id);
            context.Clientes.Remove(cliente);
            await context.SaveChangesAsync();
            return cliente;
        }
    }
}
