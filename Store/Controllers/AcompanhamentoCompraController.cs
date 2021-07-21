using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    [ApiController]
    [Route("v1/Acompanhamentocompra")]
    public class AcompanhamentoCompraController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<AcompanhamentoCompra>>> Get([FromServices] DataContext context)
        {
            var acompanhamento = await context.Acompanhamento.ToListAsync();
            return acompanhamento;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<AcompanhamentoCompra>> Post(
            [FromServices] DataContext context,
            [FromBody] AcompanhamentoCompra model)
        {
            if (ModelState.IsValid)
            {
                context.Acompanhamento.Add(model);
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
        public async Task<ActionResult<AcompanhamentoCompra>> GetById([FromServices] DataContext context, int id)
        {
            var acompanhamento = await context.Acompanhamento
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return acompanhamento;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<AcompanhamentoCompra>> Update(
            [FromServices] DataContext context,
            [FromBody] AcompanhamentoCompra acompanhamento, 
            int id)
        {
           if(id != acompanhamento.Id) { return BadRequest(); }
            context.Entry(acompanhamento).State = EntityState.Modified;

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
        public async Task<ActionResult<AcompanhamentoCompra>> Delete(
        [FromServices] DataContext context,
        int id)
        {
            var acompanhamento = await context.Acompanhamento.FindAsync(id);
            context.Acompanhamento.Remove(acompanhamento);
            await context.SaveChangesAsync();
            return acompanhamento;
        }

    }
}
