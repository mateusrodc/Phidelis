using Back.PhidelisSystem.Domain.Interfaces;
using Back.PhidelisSystem.Domain.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.PhidelisSystem.Infra.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SqlContext _context;
        public StudentRepository (SqlContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateStudent(Student model)
        {
            var student = new Student(model.name, model.mother, model.birthdate, false);

            _context.student.Add(student);
            var teste = _context.SaveChanges();

            return true;
        }
        public async Task<bool> GetStudentByNameOrMother(string name, string mother)
        {
            var result = _context.student.Where(x => x.name == name && x.mother == mother).FirstOrDefault();

            if (result == null) 
                return false;

            return true;
        }
        public async Task<List<Student>> GetStudentsRegistereds()
        {
            return _context.student.Where(x => x.registered == true).ToList();
        }
        public async Task<bool> UpdateStudent (int idStudent)
        {
            var student = _context.student.Where(x => x.id == idStudent).FirstOrDefault();
            if(student != null)
            {
                student.registered = true;
                _context.Update(student);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public async Task<Student> GetStudentById(int id)
        {
            var result = _context.student.Where(x => x.id == id).FirstOrDefault();
            return result;
        }
    }
}
