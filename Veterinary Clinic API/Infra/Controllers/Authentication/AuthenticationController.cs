using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veterinary_Clinic_API.App.Dto;
using Veterinary_Clinic_API.App.ServicesInterface.Token;

namespace Veterinary_Clinic_API.Infra.Controllers.Authentication
{
    [Route("api/Authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenServiceS _tokenSecretary;
        private readonly ITokenServiceD _tokenDoctor;
        private readonly ITokenServiceA _tokenAdm;

        public AuthenticationController(ITokenServiceS tokenSecretary, ITokenServiceD tokenDoctor, ITokenServiceA tokenAdm)
        {
            _tokenSecretary = tokenSecretary;
            _tokenDoctor = tokenDoctor;
            _tokenAdm = tokenAdm;
        }

        [HttpPost("AuthenticationSecretary")]
        public IActionResult LoginSecretary([FromForm] LoginDto login)
        {
            try
            {
                var token = _tokenSecretary.GenerateToken(login);

                if (token == "")
                {
                    return Unauthorized();
                }
                return Ok(token);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro na criação de token: {ex.Message}");
            }

        }

        [HttpPost("AuthenticationDoctor")]
        public IActionResult LoginDoctor([FromForm] LoginDto login)
        {
            try
            {
                var token = _tokenDoctor.GenerateToken(login);

                if (token == "")
                {
                    return Unauthorized();
                }
                return Ok(token);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro na criação de token: {ex.Message}");
            }
        }

        [HttpPost("AuthenticationAdmin")]
        public IActionResult LoginAdmin([FromForm] LoginDto login)
        {
            try
            {
                var token = _tokenAdm.GenerateToken(login);

                if (token == "")
                {
                    return Unauthorized();
                }
                return Ok(token);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro na criação de token: {ex.Message}");
            }
        }
    }
}
