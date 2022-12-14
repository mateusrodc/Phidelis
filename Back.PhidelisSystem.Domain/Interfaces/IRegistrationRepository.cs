using Back.PhidelisSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.PhidelisSystem.Domain.Interfaces
{
    public interface IRegistrationRepository
    {
        Task<bool> CreateRegistration(Registration registration);
        Task<bool> GetRegistrationByStudentId(int studentId);
        Task<bool> DeleteRegistration(int idRegistration);
        Task<List<Registration>> GetRegistrations();
        Task<bool> UpdateRegistration(Registration registration);
    }
}
