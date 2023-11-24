using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<GetDetailesStudentDto>> GetAllStudents()
        {
            var students = await _context.Students.Select(x => new GetDetailesStudentDto()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Code = x.Code,
                NationalId = x.NationalId
            }).ToListAsync();

            return students;
    
        }
        public async Task<GetDetailesStudentDto> GetStudentDetaile(int id)
        {
            var student = await _context.Students
                            .Where(x => x.Id == id)
                            .Select(x => new GetDetailesStudentDto()
                            {
                                Id = x.Id,
                                FirstName = x.FirstName,
                                LastName = x.LastName,
                                Code = x.Code,
                                NationalId = x.NationalId
                            })
                            .FirstOrDefaultAsync();
                            
            return student;
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