using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MsitAPI.Models;

namespace MsitAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> users = new List<User>
            {
                new User { Id = 1, Name = "Tom", Email = "Tom@gmail.com" },
                new User { Id = 2, Name = "Jack", Email = "Jack@company.com" },
                new User { Id = 3, Name = "Mary", Email = "Mary@gmail.com" }
            };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) // Removed async as List<T> does not support async methods
        {
            var user = users.FirstOrDefault(u => u.Id == id); // Replaced FirstOrDefaultAsync with FirstOrDefault
            if (user == null) return NotFound("找不到");
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            user.Id = users.Max(p => p.Id) + 1;
            users.Add(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

       
        [HttpPut("{id}")]
        public IActionResult Update(int id, User user)
        {
            var _user = users.FirstOrDefault(u => u.Id == id);
            if (_user == null) return NotFound();

            _user.Name = user.Name;
            _user.Email = user.Email;

            return NoContent();
        }

       
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();

            users.Remove(user);
            return NoContent();
        }


    }
}
