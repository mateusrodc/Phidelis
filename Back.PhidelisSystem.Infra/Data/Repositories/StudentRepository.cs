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
            var teste = (model.birthdate,DateFormat.ShortDate);
            var student = new Student(model.name, model.mother, model.birthdate, false);
            _context.Student.Add(student);
            _context.SaveChanges();
            return true;
        }
    }
}
