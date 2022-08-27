using Back.PhidelisSystem.Application.Interfaces;
using Back.PhidelisSystem.Domain.Interfaces;
using Back.PhidelisSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.PhidelisSystem.Application.Services
{
    public class StudentApplication : IStudentApplication
    {
        private readonly IStudentRepository _studentRepository;
        public StudentApplication(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<bool> CreateStudent(Student student)
        {
            var result = await _studentRepository.CreateStudent(student);
            return true;
        }
    }
}
