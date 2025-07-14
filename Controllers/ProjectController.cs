using Fluent_Migrator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Fluent_Migrator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public ProjectController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        [HttpGet("active")]
        public IActionResult GetActiveProjects()
        {
            var result = new List<Project>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("GetActiveProjects", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Project
                {
                    ProjectId = reader.GetInt32(0),
                    ProjectName = reader.GetString(1),
                    StartDate = reader.GetDateTime(2),
                    EndDate = reader.IsDBNull(3) ? null : reader.GetDateTime(3),
                    IsActive = reader.GetBoolean(4),
                    CreatedDate = reader.GetDateTime(5)
                });
            }

            return Ok(result);
        }
        [HttpPost("insert")]
        public IActionResult InsertProject([FromBody] Project model)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("InsertProject", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@ProjectName", model.ProjectName);
            cmd.Parameters.AddWithValue("@StartDate", model.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", model.EndDate ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@IsActive", model.IsActive);
            conn.Open();
            cmd.ExecuteNonQuery();
            return Ok("Project inserted successfully.");
        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = new List<Employees>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("GetAllEmployees", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                employees.Add(new Employees
                {
                    EmployeeId = reader.GetInt32(reader.GetOrdinal("EmployeeId")),
                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                    LastName = reader.GetString(reader.GetOrdinal("LastName")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    HireDate = reader.GetDateTime(reader.GetOrdinal("HireDate")),
                    IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"))
                });
            }

            return Ok(employees);
        }

        [HttpPost]
        public IActionResult InsertEmployee([FromBody] Employees employee)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("InsertEmployee", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
            cmd.Parameters.AddWithValue("@LastName", employee.LastName);
            cmd.Parameters.AddWithValue("@Email", employee.Email);
            cmd.Parameters.AddWithValue("@HireDate", employee.HireDate);
            cmd.Parameters.AddWithValue("@IsActive", employee.IsActive);

            conn.Open();
            cmd.ExecuteNonQuery();

            return Ok("Employee inserted successfully.");
        }
    }
}