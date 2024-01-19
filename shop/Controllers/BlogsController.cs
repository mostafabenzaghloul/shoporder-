using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop.Dto;
using shop.Models;
using shop.Services;

namespace shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BlogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blog>>> GetProducts()
        {
            return await _context.bl.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetProduct(int id)
        {
            var product = await _context.bl.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }


        [HttpPost]
        public async Task<ActionResult<Blog>> PostProduct([FromForm] ProductCreateModel model)
        {
            var product = new Blog
            {
                Title = model.Title,
                Descreption = model.Description,
                Poster = await GetByteArrayFromFormFile(model.Image)
            };

            _context.bl.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, [FromBody] ProductUpdateModel model)
        {
            var product = await _context.bl.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            product.Title = model.Title;
            product.Descreption = model.Description;

            if (model.Image != null)
            {
                product.Poster = await GetByteArrayFromFormFile(model.Image);
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.bl.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.bl.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.bl.Any(e => e.Id == id);
        }

        private async Task<byte[]> GetByteArrayFromFormFile(IFormFile file)
        {
            if (file == null)
            {
                return null;
            }

            using (MemoryStream ms = new MemoryStream())
            {
                await file.CopyToAsync(ms);
                return ms.ToArray();
            }
        }
    }
}
