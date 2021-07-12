using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    [ApiController]
    [Route("v1/compra")]
    public class CompraController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Compra>>> Get([FromServices] DataContext context)
        {
            var compra = await context.Compra.ToListAsync();
            return compra;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Compra>> Post(
            [FromServices] DataContext context,
            [FromBody] Compra model)
        {
            if (ModelState.IsValid)
            {
                context.Compra.Add(model);
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
