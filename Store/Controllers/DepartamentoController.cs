using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    [ApiController]
    [Route("v1/Departamento")]
    public class DepartamentoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Departamento>>> Get([FromServices] DataContext context)
        {
            var departamento = await context.Departamento.ToListAsync();
            return departamento;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Departamento>> Post(
            [FromServices] DataContext context,
            [FromBody] Departamento model)
        {
            if (ModelState.IsValid)
            {
                context.Departamento.Add(model);
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
