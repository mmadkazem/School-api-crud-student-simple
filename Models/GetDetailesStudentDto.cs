using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Models
{
    public class GetDetailesStudentDto
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Code { get; set; }
        public required string NationalId { get; set; }
    }
}