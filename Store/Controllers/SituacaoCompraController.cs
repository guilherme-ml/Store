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
            var situacao = await context.Situacaocompra.ToListAsync();
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
                context.Situacaocompra.Add(model);
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
