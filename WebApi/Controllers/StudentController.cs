using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Interface;

namespace WebApi.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentRepository _StudentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _StudentRepository = studentRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetStudents()
        {
            try
            {
                return Ok(await _StudentRepository.GetStudents());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro in retrieving data from database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            try
            {
                var result = await _StudentRepository.GetStudent(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro in retrieving data from database");
            }
        }
        [HttpPost]
        public async Task<ActionResult> AddStudent(Student student)
        {
            try
            {
                if (student == null)
                {
                    return BadRequest();
                }
                var CreateStudent = await _StudentRepository.AddStudent(student);
                return CreatedAtAction(nameof(AddStudent), new { id = CreateStudent.Id }, CreateStudent);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro in retrieving data from database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, Student student)
        {
            try
            {
                if (id != student.Id)
                {
                    return BadRequest("Id is not match");
                }
                var studentUpdated = await _StudentRepository.GetStudent(id);
                if (studentUpdated == null)
                {
                    return NotFound($"User {id} is not found");
                }
                var UpdatedStudent = await _StudentRepository.UpdateStudent(student);
                return UpdatedStudent;
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro in retrieving data from database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            try
            {

                var studentDelete = await _StudentRepository.GetStudent(id);

                if (studentDelete != null)
                {
                    var student = await _StudentRepository.DeleteStudent(id);
                    return student;
                }
                return null;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro in retrieving data from database");
            }
        }
        [HttpGet("{Search},Student")]
        public async Task<ActionResult<IEnumerable<Student>>> Search(string FirstName)
        {
            try
            {
                var result = await _StudentRepository.Search(FirstName);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro in retrieving data from database");
            }
        }
    }
}
