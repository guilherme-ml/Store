using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
namespace Store.Controllers
{
    [ApiController]
    [Route("v1/grupo")]
    public class GrupoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Grupo>>> Get([FromServices] DataContext context)
        {
            var grupo = await context.Grupo.ToListAsync();
            return grupo;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Grupo>> Post(
            [FromServices] DataContext context,
            [FromBody] Grupo model)
        {
            if (ModelState.IsValid)
            {
                context.Grupo.Add(model);
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
