using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School.Data.Context;
using School.Data.Entity;
using School.Models;

namespace School.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateStudent(CreateStudentDto studentDto)
        {
            var student = new Student()
            {
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                Code = studentDto.Code,
                NationalId = studentDto.NationalId
            };

            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }
    }
}