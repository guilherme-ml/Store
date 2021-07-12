using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    [ApiController]
    [Route("v1/condicaopagamento")]
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
    }
}
