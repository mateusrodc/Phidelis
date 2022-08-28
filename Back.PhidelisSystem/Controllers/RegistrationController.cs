using Back.PhidelisSystem.Application.Interfaces;
using Back.PhidelisSystem.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Back.PhidelisSystem.Controllers
{
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationApplication _registrationApplication;

        public RegistrationController(IRegistrationApplication registrationApplication)
        {
            _registrationApplication = registrationApplication;
        }
        [HttpPost]
        [Route("newregistration")]
        public async Task<dynamic> CreateRegistration([FromBody] Registration model)
        {
            try
            {
                var result = await _registrationApplication.CreateRegistration(model);
                if (result)
                {
                    return new
                    {
                        message = "Registration has been created"
                    };
                }
                return new
                {
                    message = "Registration has'nt been created"
                };
            }
            catch(Exception e)
            {
                return new
                {
                    message = e.Message
                };
            }
            
        }
    }
}
