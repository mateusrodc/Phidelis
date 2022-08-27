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
        Task<bool> CreateStudent(Student student);
    }
}
