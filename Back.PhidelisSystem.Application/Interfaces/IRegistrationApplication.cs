using Back.PhidelisSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.PhidelisSystem.Application.Interfaces
{
    public interface IRegistrationApplication
    {
        Task<bool> CreateRegistration(Registration registration);
        Task<bool> GetRegistrationByStudentId(int studentId);
    }
}
