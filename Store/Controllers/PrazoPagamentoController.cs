using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    [ApiController]
    [Route("v1/prazo")]
    public class PrazoPagamentoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<PrazoPagamento>>> Get([FromServices] DataContext context)
        {
            var prazo = await context.Prazo.ToListAsync();
            return prazo;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<PrazoPagamento>> Post(
            [FromServices] DataContext context,
            [FromBody] PrazoPagamento model)
        {
            if (ModelState.IsValid)
            {
                context.Prazo.Add(model);
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
