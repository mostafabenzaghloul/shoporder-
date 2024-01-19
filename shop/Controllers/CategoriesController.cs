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
    public class CategoriesController : ControllerBase
    {


        private readonly ICategoriesServices _genresService;

        public CategoriesController(ICategoriesServices genresService)
        {
            _genresService = genresService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var genres = await _genresService.GetAll();

            return Ok(genres);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync(CategoriesDto dto)
        {
            var genre = new Category { Name = dto.Name,
            Description = dto.Description};

            await _genresService.Add(genre);

            return Ok(genre);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(byte id, [FromBody] CategoriesDto dto)
        {
            var genre = await _genresService.GetById(id);

            if (genre == null)
                return NotFound($"No genre was found with ID: {id}");

            genre.Name = dto.Name;
            genre.Description = dto.Description;

            _genresService.Update(genre);

            return Ok(genre);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(byte id)
        {
            var genre = await _genresService.GetById(id);

            if (genre == null)
                return NotFound($"No genre was found with ID: {id}");

            _genresService.Delete(genre);

            return Ok(genre);
        }

       

    }
}
