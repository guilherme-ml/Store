using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
namespace Store.Controllers
{
    [ApiController]
    [Route("v1/Grupo")]
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
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Grupo>> GetById([FromServices] DataContext context, int id)
        {
            var grupo = await context.Grupo
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return grupo;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Grupo>> Update(
            [FromServices] DataContext context,
            [FromBody] Grupo grupo,
            int id)
        {
            if (id != grupo.Id) { return BadRequest(); }
            context.Entry(grupo).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Grupo>> Delete(
        [FromServices] DataContext context,
        int id)
        {
            var grupo = await context.Grupo.FindAsync(id);
            context.Grupo.Remove(grupo);
            await context.SaveChangesAsync();
            return grupo;
        }
    }
}
