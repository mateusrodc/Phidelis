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
            var regist = new Registration(DateTime.UtcNow, registration.studentid, registration.grade, registration.lesson);
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
    }
}