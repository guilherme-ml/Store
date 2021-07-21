using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    [ApiController]
    [Route("v1/situacao")]
    public class SituacaoCompraController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<SituacaoCompra>>> Get([FromServices] DataContext context)
        {
            var situacao = await context.Situacao.ToListAsync();
            return situacao;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<SituacaoCompra>> Post(
            [FromServices] DataContext context,
            [FromBody] SituacaoCompra model)
        {
            if (ModelState.IsValid)
            {
                context.Situacao.Add(model);
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
        public async Task<ActionResult<SituacaoCompra>> GetById([FromServices] DataContext context, int id)
        {
            var situacao = await context.Situacao
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return situacao;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<SituacaoCompra>> Update(
            [FromServices] DataContext context,
            [FromBody] SituacaoCompra situacao,
            int id)
        {
            if (id != situacao.Id) { return BadRequest(); }
            context.Entry(situacao).State = EntityState.Modified;

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
        public async Task<ActionResult<SituacaoCompra>> Delete(
        [FromServices] DataContext context,
        int id)
        {
            var situacao = await context.Situacao.FindAsync(id);
            context.Situacao.Remove(situacao);
            await context.SaveChangesAsync();
            return situacao;
        }
    }
}
