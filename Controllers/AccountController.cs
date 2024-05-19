using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPWebApi.DTO;
using ERPWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERPWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ErpdbconnectContext _context;
        public AccountController(ErpdbconnectContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
        {
            var employees = await _context.Temployees
                .Select(e => new EmployeeDto
                {
                    EmpId = e.EmpId,
                    EmpFirstname = e.EmpFirstname,
                    EmpLastname = e.EmpLastname,
                    EmpPositionName = e.EmpPosition != null ? e.EmpPosition.EmpPositionName : null
                })
                .ToListAsync();

            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(string id)
        {
            var employee = await _context.Temployees
                .Where(e => e.EmpId == id)
                .Select(e => new EmployeeDto
                {
                    EmpId = e.EmpId,
                    EmpFirstname = e.EmpFirstname,
                    EmpLastname = e.EmpLastname,
                    EmpPositionName = e.EmpPosition != null ? e.EmpPosition.EmpPositionName : null
                })
                .FirstOrDefaultAsync();

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var employee = await _context.Temployees
                .Where(e => e.EmpUsername == loginRequest.Username && e.EmpPassword == loginRequest.Password)
                .Select(e => new EmployeeDto
                {
                    EmpId = e.EmpId,
                    EmpFirstname = e.EmpFirstname,
                    EmpLastname = e.EmpLastname,
                    EmpPositionName = e.EmpPosition != null ? e.EmpPosition.EmpPositionName : null
                })
                .FirstOrDefaultAsync();

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
    }
    public class LoginRequest
    {

        public string Username { get; set; }
        public string Password { get; set; }
    }

}