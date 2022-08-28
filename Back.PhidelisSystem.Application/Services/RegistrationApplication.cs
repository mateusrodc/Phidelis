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
    public class RegistrationApplication : IRegistrationApplication
    {
        private readonly IRegistrationRepository _registrationRepository;
        private readonly IStudentRepository _studentRepository;

        public RegistrationApplication(IRegistrationRepository registrationRepository, IStudentRepository studentRepository)
        {
            _registrationRepository = registrationRepository;
            _studentRepository = studentRepository;
        }
        public async Task<bool> CreateRegistration(Registration registration)
        {
            var verifyRegistration = await GetRegistrationByStudentId(registration.studentid);
            var result = false;

            if(!verifyRegistration)
                result = await _registrationRepository.CreateRegistration(registration);
            

            if (result)
            {
                await _studentRepository.UpdateStudent(registration.studentid);
            }
            return result;
        }
        public async Task<bool> GetRegistrationByStudentId(int studentId)
        {
            return await _registrationRepository.GetRegistrationByStudentId(studentId);
        }
    }
}
