using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    [ApiController]
    [Route("v1/prazopagamento")]
    public class PrazoCondPagamentoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<PrazoCondPagamento>>> Get([FromServices] DataContext context)
        {
            var prazo = await context.PrazoCondPagamento.ToListAsync();
            return prazo;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<PrazoCondPagamento>> Post(
            [FromServices] DataContext context,
            [FromBody] PrazoCondPagamento model)
        {
            if (ModelState.IsValid)
            {
                context.PrazoCondPagamento.Add(model);
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
