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

                if (result)
                {
                    return new
                    {
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
    }
}
