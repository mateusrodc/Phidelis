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
            var result = await _studentApplication.CreateStudent(model);
            return new 
            {
                message = "Student has been created"
            };
        }
    }
}
