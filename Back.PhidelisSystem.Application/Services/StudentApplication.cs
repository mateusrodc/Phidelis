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
            var studentExists = await GetStudentByNameOrMother(student.name, student.mother);

            if (!studentExists)

                return await _studentRepository.CreateStudent(student);

            return false;
            
            
        }
        public async Task<bool> GetStudentByNameOrMother(string name, string mother)
        {
            return await _studentRepository.GetStudentByNameOrMother(name,mother);
        }
        public async Task<List<Student>> GetStudentsRegistereds()
        {
            return await _studentRepository.GetStudentsRegistereds();
        }
        public async Task<Student> GetStudentById(int id)
        {
            return await _studentRepository.GetStudentById(id);
        }
    }
}
