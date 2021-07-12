using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    [ApiController]
    [Route("v1/caracteristica")]
    public class CaracteristicaController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Caracteristica>>> Get([FromServices] DataContext context)
        {
            var caracteristica = await context.Caracteristica.ToListAsync();
            return caracteristica;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Caracteristica>> Post(
            [FromServices] DataContext context,
            [FromBody] Caracteristica model)
        {
            if (ModelState.IsValid)
            {
                context.Caracteristica.Add(model);
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
