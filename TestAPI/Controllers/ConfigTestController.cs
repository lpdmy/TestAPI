using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigTestController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public ConfigTestController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet("show")]
        public IActionResult ShowConfig()
        {
            // Lấy key từ App Settings (Azure Configuration → Application Settings)
            var customValue = _configuration["MyCustomKey"] ?? "Not Found";

            // Lấy connection string
            var connString = _configuration.GetConnectionString("DefaultConnection")
                             ?? "Connection string not found";

            return Ok(new
            {
                Environment = _env.EnvironmentName,
                CustomValue = customValue,
                ConnectionString = connString
            });
        }

        [HttpGet("show3")]
        public IActionResult ShowConfig3()
        {
            // Lấy key từ App Settings (Azure Configuration → Application Settings)
            var customValue = _configuration["MyCustomKey"] ?? "Not Found";

            // Lấy connection string
            var connString = _configuration.GetConnectionString("DefaultConnection")
                             ?? "Connection string not found";

            return Ok(new
            {
                Environment = _env.EnvironmentName,
                CustomValue = customValue,
                ConnectionString = connString
            });
        }
    }
}
