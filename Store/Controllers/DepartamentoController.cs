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
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Departamento>> GetById([FromServices] DataContext context, int id)
        {
            var departamento = await context.Departamento
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return departamento;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Departamento>> Update(
            [FromServices] DataContext context,
            [FromBody] Departamento departamento,
            int id)
        {
            if (id != departamento.Id) { return BadRequest(); }
            context.Entry(departamento).State = EntityState.Modified;

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
        public async Task<ActionResult<Departamento>> Delete(
        [FromServices] DataContext context,
        int id)
        {
            var departamento = await context.Departamento.FindAsync(id);
            context.Departamento.Remove(departamento);
            await context.SaveChangesAsync();
            return departamento;
        }
    }
}
