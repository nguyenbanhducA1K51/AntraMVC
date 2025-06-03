using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data; // Assuming MovieShopDbContext is here

namespace MovieShopMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbTestController : ControllerBase
    {
        private readonly MovieShopDbContext _context;

        public DbTestController(MovieShopDbContext context)
        {
            _context = context;
        }

        [HttpGet("test-connection")]
        public async Task<IActionResult> TestConnection()
        {
            try
            {
                var canConnect = await _context.Database.CanConnectAsync();
                
                if (canConnect)
                {
                    var version = await _context.Database.ExecuteSqlRawAsync("SELECT @@VERSION");
                    return Ok(new {
                        Status = "Connected",
                        DatabaseVersion = version.ToString()
                    });
                }
                
                return StatusCode(500, "Could not connect to database");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Connection failed: {ex.Message}");
            }
        }
    }
}