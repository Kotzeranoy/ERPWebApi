using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPWebApi.DTO
{
    public class EmployeeDto
    {
        public string? EmpId { get; set; }
        public string? EmpFirstname { get; set; }
        public string? EmpLastname { get; set; }
        public string? EmpPositionName { get; set; }
    }
}