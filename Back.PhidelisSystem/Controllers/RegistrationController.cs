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
        [HttpDelete]
        [Route("deleteregistration")]
        public async Task<dynamic> DeleteRegistration([FromQuery] int id)
        {
            try
            {
                var result = await _registrationApplication.DeleteRegistration(id);
                if (result)
                {
                    return new
                    {
                        message = "Registration has been deleted"
                    };
                }
                return new
                {
                    message = "Registration has'nt been deleted"
                };
            }
            catch (Exception e)
            {
                return new
                {
                    message = e.Message
                };
            }
            
        }
        [HttpGet]
        [Route("registrations")]
        public async Task<List<Registration>> GetRegistrations()
        {
            return await _registrationApplication.GetRegistrations();
        }
        [HttpPut]
        [Route("updateregistration")]
        public async Task<ActionResult<dynamic>> UpdateRegistration([FromBody] Registration model)
        {
            try
            {
                var result = await _registrationApplication.UpdateRegistration(model);
                if(result)
                {
                    return new
                    {
                        message = "Registration updated succesful"
                    };
                }
                else
                {
                    return new
                    {
                        message = "Registration not updated"
                    };
                }
            }
            catch(Exception e)
            {
                return new
                {
                    error = e.Message
                };
            }
            
        }
        
    }
}
