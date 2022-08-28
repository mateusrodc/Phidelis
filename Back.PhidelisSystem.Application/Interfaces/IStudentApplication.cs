using Back.PhidelisSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.PhidelisSystem.Application.Interfaces
{
    public interface IStudentApplication
    {
        Task<bool> CreateStudent(Student student);
        Task<bool> GetStudentByNameOrMother(string name, string mother);
        Task<List<Student>> GetStudentsRegistereds();
        Task<Student> GetStudentById(int id);
    }
}
