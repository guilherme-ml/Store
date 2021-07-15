using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    [ApiController]
    [Route("v1/Condicaopagamento")]
    public class CondicaoPagamentoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<CondPagamento>>> Get([FromServices] DataContext context)
        {
            var condicao = await context.Condicao.ToListAsync();
            return condicao;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<CondPagamento>> Post(
            [FromServices] DataContext context,
            [FromBody] CondPagamento model)
        {
            if (ModelState.IsValid)
            {
                context.Condicao.Add(model);
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
        public async Task<ActionResult<CondPagamento>> GetById([FromServices] DataContext context, int id)
        {
            var condicao = await context.Condicao
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return condicao;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<CondPagamento>> Update(
            [FromServices] DataContext context,
            [FromBody] CondPagamento condicao,
            int id)
        {
            if (id != condicao.Id) { return BadRequest(); }
            context.Entry(condicao).State = EntityState.Modified;

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
