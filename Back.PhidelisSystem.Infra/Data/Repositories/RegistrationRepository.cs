using Back.PhidelisSystem.Domain.Interfaces;
using Back.PhidelisSystem.Domain.Models;
using Back.PhidelisSystem.Infra.Data;

namespace Back.PhidelisSystem.Infra
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly SqlContext _context;
        public RegistrationRepository(SqlContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateRegistration(Registration registration)
        {
            var regist = new Registration(registration.studentid, registration.grade, registration.lesson);
            _context.registration.Add(regist);
            _context.SaveChanges();

            return true;
        }
        public async Task<bool> GetRegistrationByStudentId(int studentId)
        {
            var result = _context.registration.Where(x => x.studentid == studentId).FirstOrDefault();
            if(result == null)
            {
                return false;
            }
            return true;
        }
        public async Task<bool> DeleteRegistration(int idRegistration)
        {
            var registration = _context.registration.Where(x => x.id == idRegistration).FirstOrDefault();
            if(registration != null)
            {
                _context.registration.Remove(registration);
                _context.SaveChanges();

                return true;
            }
            return false;
        }
        public async Task<List<Registration>> GetRegistrations()
        {
            var result = _context.registration.ToList();
            return result;
        }
        public async Task<bool> UpdateRegistration(Registration registration)
        {
            var register = _context.registration.Where(x => x.id == registration.id).FirstOrDefault();
            if(register != null)
            {
                _context.registration.Update(registration);
                _context.SaveChanges();
                return true;
            }
            
            return false;
        }
    }
}