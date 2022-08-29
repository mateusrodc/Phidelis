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
                await _studentRepository.UpdateStudent(registration.studentid, true);
            }
            return result;
        }
        public async Task<bool> GetRegistrationByStudentId(int studentId)
        {
            return await _registrationRepository.GetRegistrationByStudentId(studentId);
        }
        public async Task<bool> DeleteRegistration(int idRegistration)
        {
            var result = await _registrationRepository.DeleteRegistration(idRegistration);

            if(result)
                await _studentRepository.UpdateStudent(idRegistration, false);

            return result;
        }
        public async Task<List<Registration>> GetRegistrations()
        {
            return await _registrationRepository.GetRegistrations();
        }
        public async Task<bool> UpdateRegistration(Registration registration)
        {
            if(ValidateUpdateRegistration(registration))

                return await _registrationRepository.UpdateRegistration(registration);

            else
            {
                return false;
            }
        }
        private bool ValidateUpdateRegistration(Registration registration)
        {
            if (registration == null)
            {
                return false;
            }
            else if (registration.id <= 0 || registration.studentid <= 0)
            {
                return false;
            }
            else if (string.IsNullOrEmpty(registration.grade) || string.IsNullOrEmpty(registration.lesson))
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
    }
}
