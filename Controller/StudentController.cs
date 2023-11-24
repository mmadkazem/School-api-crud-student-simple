using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.Repository;

namespace School.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {

        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentRepository.GetAllStudents();
            return Ok(students);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentDetaile(int id)
        {
            var student = await _studentRepository.GetStudentDetaile(id);
            if (student == null)
            {
                return NotFound("this student Not Found");
            }
            return Ok(student);
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentDto model)
        {
            if (model == null)
            {
                return BadRequest("this student is null");
            }
            await _studentRepository.CreateStudent(model);
            return Ok("this is student created!!!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, UpdateStudentDto model)
        {
            var result = await _studentRepository.UpdateStudent(id, model);
            if (result == false)
            {
                return BadRequest("This is student Not Found!!!");
            }
            return Ok("This");
            
        }
    }
}