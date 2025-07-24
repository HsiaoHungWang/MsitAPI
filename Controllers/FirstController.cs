using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MsitAPI.Models;
using MsitAPI.Models.Dto;

namespace MsitAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirstController : ControllerBase
    {
        private readonly ClassDbContext _dbContext;
        public FirstController(ClassDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        

        [HttpGet("text")]
        //?name=Tom&age=20&email=Tom@company.com&phone=123444
        //public IActionResult GetText(int age, string name)

		public IActionResult GetText([FromQuery]MyDto myDto)
		{
           // System.Threading.Thread.Sleep(5000);

            string message = $"Hello {myDto.Name}, You are {myDto.Age} years old.";
            return Content(message, "text/plain", System.Text.Encoding.UTF8);
        }

        [HttpGet("image")]
        public IActionResult GetImage1()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "avatars", "cat1.jpg");
            var imageBytes = System.IO.File.ReadAllBytes(filePath);
            return File(imageBytes, "image/jpeg");
        }

        [HttpGet("image/{id}")]
        public IActionResult GetImage2(int id)
        {
            var member = _dbContext.Members.Find(id);

            if (member == null || member.FileData == null)
            {
                return NotFound("找不到對應的圖片資料");
            }                

            return File(member.FileData, "image/jpeg");


        }
    }
}
