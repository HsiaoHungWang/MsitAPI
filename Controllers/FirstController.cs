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
    
        //public IActionResult GetText(string name, int age)
        public IActionResult GetText([FromQuery] MyDdto myDto)
        {
            //System.Threading.Thread.Sleep(5000);
            string message = "Hello 中文!!";
            message = $"Name: {myDto.Name}, Age: {myDto.Age}";

            return Content(message, "text/plain", System.Text.Encoding.UTF8);
        }

        [HttpGet("image")]
        public IActionResult GetImage1()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "dog1.jpg");
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
