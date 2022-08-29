using Back.PhidelisSystem.Application.Interfaces;
using Back.PhidelisSystem.Domain.Interfaces;
using Back.PhidelisSystem.Domain.Models;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<dynamic> CreateStudent(Student student)
        {
            var studentExists = await GetStudentByNameOrMother(student.name, student.mother);

            if (studentExists == false)
            {
                var valor = await _studentRepository.CreateStudent(student);
                return valor;
            }
            return null;
            
            
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
        public async Task<List<Student>> FilterStudentByName(string name)
        {
            var students = await _studentRepository.FilterStudentByName(name);
            return students;
        }
    }
}
