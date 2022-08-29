using Back.PhidelisSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.PhidelisSystem.Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task<dynamic> CreateStudent(Student student);
        Task<bool> GetStudentByNameOrMother(string name, string mother);
        Task<List<Student>> GetStudentsRegistereds();
        Task<bool> UpdateStudent (int idStudent, bool registered);
        Task<Student> GetStudentById(int id);
        Task<List<Student>> FilterStudentByName(string name);
    }
}
