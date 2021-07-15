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
            var acompanhamento = await context.Acompanhamento.Include(x => x.Id)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return acompanhamento;
        }

        [HttpPut("{id:length(24)}")]
        public async Task<ActionResult<AcompanhamentoCompra>> Update(
            [FromServices] DataContext context,
            [FromBody] AcompanhamentoCompra model,
            int id)
        {
            int i = 0;
            var aux = await context.Acompanhamento.ToListAsync();
            while (i <= aux.Count ) {
                if(aux[i].Id == id)
                {
                    return aux[i];
                }
                i++;
            }

            return NoContent();
        }

    }
}
