using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School.Models;

namespace School.Repository
{
    public interface IStudentRepository
    {
        Task CreateStudent(CreateStudentDto studentDto);
        Task<List<GetDetailesStudentDto>> GetAllStudents();
        Task<GetDetailesStudentDto> GetStudentDetaile(int id);
        Task<bool> UpdateStudent(int id, UpdateStudentDto model);
        Task<bool> RemoveStudent(int id);
    }
}