using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    [ApiController]
    [Route("v1/categoria")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Category>>> Get([FromServices] DataContext context)
        {
            var categories = await context.Categories.ToListAsync();
            return categories;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Category>> Post(
            [FromServices] DataContext context,
            [FromBody] Category model)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Add(model);
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
        public async Task<ActionResult<Category>> GetById([FromServices] DataContext context, int id)
        {
            var categoria = await context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return categoria;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Category>> Update(
            [FromServices] DataContext context,
            [FromBody] Category categoria,
            int id)
        {
            if (id != categoria.Id) { return BadRequest(); }
            context.Entry(categoria).State = EntityState.Modified;

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
        public async Task<ActionResult<Category>> Delete(
        [FromServices] DataContext context,
        int id)
        {
            var categoria = await context.Categories.FindAsync(id);
            context.Categories.Remove(categoria);
            await context.SaveChangesAsync();
            return categoria;
        }
    }
}
