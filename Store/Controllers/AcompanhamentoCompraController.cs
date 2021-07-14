using System.Collections.Generic;
using System.Threading.Tasks;
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
    }
}
