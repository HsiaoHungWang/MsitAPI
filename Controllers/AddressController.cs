using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MsitAPI.Models;

namespace MsitAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly ClassDbContext _dbContext;
        public AddressController(ClassDbContext dbContext) {
            _dbContext = dbContext;
        }

        //讀取所有城市
        [HttpGet("city")]
        public async Task<IActionResult> GetCity() {
            var cities = await _dbContext.Addresses.OrderBy(a => a.City).Select(a => a.City).Distinct().ToListAsync();
            return Ok(cities);
        }

        //根據城市讀取所有鄉鎮區
        [HttpGet("district/{city}")]
        public async Task<IActionResult> GetDistrict(string city)
        {
            var sites = await _dbContext.Addresses.Where(a => a.City == city).OrderBy(a => a.SiteId).Select(a => a.SiteId).Distinct().ToListAsync();
            return Ok(sites);
        }

        //根據鄉鎮區讀取所有路名
        [HttpGet("roads/{site}")]
        public async Task<IActionResult> Roads(string site)
        {
            var roads = await _dbContext.Addresses.Where(a => a.SiteId == site).OrderBy(a => a.Road).Select(a => a.Road).Distinct().ToListAsync();
            return Ok(roads);
        }
    }
}
