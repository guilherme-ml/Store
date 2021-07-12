using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    [ApiController]
    [Route("v1/fabricante")]
    public class FabricanteController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Fabricante>>> Get([FromServices] DataContext context)
        {
            var fabricante = await context.Fabricantes.ToListAsync();
            return fabricante;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Fabricante>> Post(
            [FromServices] DataContext context,
            [FromBody] Fabricante model)
        {
            if (ModelState.IsValid)
            {
                context.Fabricantes.Add(model);
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

