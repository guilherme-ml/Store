using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
namespace Store.Controllers
{
    [ApiController]
    [Route("v1/Promocao")]
    public class PromocaoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Promocao>>> Get([FromServices] DataContext context)
        {
            var promocao = await context.Promocao.ToListAsync();
            return promocao;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Promocao>> Post(
            [FromServices] DataContext context,
            [FromBody] Promocao model)
        {
            if (ModelState.IsValid)
            {
                context.Promocao.Add(model);
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
