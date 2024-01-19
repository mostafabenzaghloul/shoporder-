using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop.Models;
using shop.Dto;
using shop.Services;

namespace shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {


       

        private readonly IAdminServices _genresService;

        public AdminsController(IAdminServices genresService)
        {
            _genresService = genresService;
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel request)
        {
            // Validate request data
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Username and password are required.");
            }

            // Authenticate user
            var user = _genresService.Authenticate(request.Email, request.Password);

            if (user == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            // You can return additional user information if needed
            return Ok(new { UserId = user.Id, Username = user.Email });
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var genres = await _genresService.GetAll();

            return Ok(genres);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Admin admin)
        {
            var genre = new Admin { name = admin.name, Email = admin.Email,Password =admin.Password };

            await _genresService.Add(genre);

            return Ok(genre);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(byte id, [FromBody] Admin dto)
        {
            var genre = await _genresService.GetById(id);

            if (genre == null)
                return NotFound($"No genre was found with ID: {id}");

            genre.name = dto.name;
            genre.Email = dto.Email;
            genre.Password = dto.Password;


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


        //[HttpPost("login")]
        //public IActionResult Login([FromBody] LoginModel model)
        //{
        //    var user = _context.admins.SingleOrDefault(u => u.Email == model.Email && u.Password == model.Password);

        //    if (user != null)
        //    {
        //        // Authentication succeeded
        //        return Ok("Login successful");
        //    }

        //    // Authentication failed
        //    return Unauthorized("Invalid username or password");
        //}

       
        //private bool AdminExists(long id)
        //{
        //    return (_context.admins?.Any(e => e.Id == id)).GetValueOrDefault();
        //}

    }
}
