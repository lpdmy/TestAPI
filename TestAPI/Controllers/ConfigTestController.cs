using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient; // namespace mới

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
        [HttpGet("show2")]
        public IActionResult ShowConfig2()
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
        [HttpGet("test-users")]
        public IActionResult TestUsers()
        {
            var connString = _configuration.GetConnectionString("DefaultConnection");
            var users = new List<object>();

            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT TOP 10 Id, UserName, Email FROM AppUsers", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new
                        {
                            Id = reader["Id"],
                            UserName = reader["UserName"],
                            Email = reader["Email"]
                        });
                    }
                }
            }

            return Ok(users);
        }

    }


}