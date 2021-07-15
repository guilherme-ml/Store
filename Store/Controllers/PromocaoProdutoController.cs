using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    [ApiController]
    [Route("v1/Promocaoproduto")]
    public class PromocaoProdutoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<PromoProduto>>> Get([FromServices] DataContext context)
        {
            var promocaoproduto = await context.PromoProduto.ToListAsync();
            return promocaoproduto;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<PromoProduto>> Post(
            [FromServices] DataContext context,
            [FromBody] PromoProduto model)
        {
            if (ModelState.IsValid)
            {
                context.PromoProduto.Add(model);
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
        public async Task<ActionResult<PromoProduto>> GetById([FromServices] DataContext context, int id)
        {
            var promoProduto = await context.PromoProduto
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return promoProduto;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<PromoProduto>> Update(
            [FromServices] DataContext context,
            [FromBody] PromoProduto promoProduto,
            int id)
        {
            if (id != promoProduto.Id) { return BadRequest(); }
            context.Entry(promoProduto).State = EntityState.Modified;

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
    }
}
