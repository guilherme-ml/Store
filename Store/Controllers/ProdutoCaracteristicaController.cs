using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    [ApiController]
    [Route("v1/produtocaracteristica")]
    public class ProdutoCaracteristicaController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<ProdutoCaracteristica>>> Get([FromServices] DataContext context)
        {
            var prodcaracteristica = await context.ProdCaracteristica.ToListAsync();
            return prodcaracteristica;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<ProdutoCaracteristica>> Post(
            [FromServices] DataContext context,
            [FromBody] ProdutoCaracteristica model)
        {
            if (ModelState.IsValid)
            {
                context.ProdCaracteristica.Add(model);
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
