using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{

    [ApiController]
    [Route("v1/Itemcompra")]
    public class ItemCompraController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<ItemCompra>>> Get([FromServices] DataContext context)
        {
            var itemCompra = await context.ItemCompra.ToListAsync();
            return itemCompra;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<ItemCompra>> Post(
            [FromServices] DataContext context,
            [FromBody] ItemCompra model)
        {
            if (ModelState.IsValid)
            {
                context.ItemCompra.Add(model);
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
