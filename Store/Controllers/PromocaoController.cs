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
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Promocao>> GetById([FromServices] DataContext context, int id)
        {
            var promocao = await context.Promocao
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return promocao;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Promocao>> Update(
            [FromServices] DataContext context,
            [FromBody] Promocao promocao,
            int id)
        {
            if (id != promocao.Id) { return BadRequest(); }
            context.Entry(promocao).State = EntityState.Modified;

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
        public async Task<ActionResult<Promocao>> Delete(
        [FromServices] DataContext context,
        int id)
        {
            var promocao = await context.Promocao.FindAsync(id);
            context.Promocao.Remove(promocao);
            await context.SaveChangesAsync();
            return promocao;
        }
    }
}
