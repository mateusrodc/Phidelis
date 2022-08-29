using Back.PhidelisSystem.Application.Interfaces;
using Back.PhidelisSystem.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Back.PhidelisSystem.Controllers
{
    public class StudentController : ControllerBase
    {
        private readonly IStudentApplication _studentApplication;

        public StudentController(IStudentApplication studentApplication)
        {
            _studentApplication = studentApplication;
        }
        [HttpPost]
        [Route("newstudent")]
        public async Task<ActionResult<dynamic>> CreateStudent([FromBody] Student model)
        {
            try
            {
                var result = await _studentApplication.CreateStudent(model);

                if (result != null)
                {
                    return new
                    {
                        id = result,
                        message = "Student has been created"
                    };
                }
                return new
                {
                    message = "Student already exists"
                };
            }
            catch (Exception e)
            {
                return new
                {
                    message = e.Message
                };
            }
        }
        [HttpGet]
        [Route("registereds")]
        public async Task<ActionResult<List<Student>>> GetStudentsRegistereds()
        {
            try
            {
                return await _studentApplication.GetStudentsRegistereds();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        [HttpGet]
        [Route("filterbyname")]
        public async Task<List<Student>> FilterStudentByName([FromQuery] string name)
        {
            try
            {
                var students = await _studentApplication.FilterStudentByName(name);

                if(students != null)
                {
                    return students;
                }

                throw new Exception("No student found");
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
