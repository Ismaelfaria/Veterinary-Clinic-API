using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.App.ServicesInterface.IDeleteService;
using Veterinary_Clinic_API.App.ServicesInterface.IGetService;
using Veterinary_Clinic_API.App.ServicesInterface.IUpdateService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.Infra.Controllers
{
    [Route("api/SecretariatHome")]
    [ApiController]
    public class SecretariaController : ControllerBase
    {
        private readonly ICreateSecretariat _serviceCreate;
        private readonly IDeleteSecretariat _serviceDelete;
        private readonly IGetSecretariat _serviceGet;
        private readonly IUpdateSecretariat _serviceUpdate;

        public SecretariaController(ICreateSecretariat serviceCreate, IDeleteSecretariat serviceDelete, IGetSecretariat serviceGet, IUpdateSecretariat serviceUpdate)
        {
            _serviceCreate = serviceCreate;
            _serviceDelete = serviceDelete;
            _serviceGet = serviceGet;
            _serviceUpdate = serviceUpdate;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var allRegistration = _serviceGet.FindAll();
                return Ok(allRegistration);
            }
            catch (Exception ex)
            {
                return StatusCode(404, $"Erro do GetAll(Controller): {ex.Message}");
            }
        }
        [HttpGet("{cpf}")]
        public IActionResult GetByCpf(int cpf)
        {
            try
            {
                var Registration = _serviceGet.FindByCpf(cpf);
                return Ok(Registration);
            }
            catch (Exception ex)
            {
                return StatusCode(404, $"Erro do GetAll(Controller): {ex.Message}");
            }
        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            try
            {
                var register = _serviceGet.FindByUserName(name);
                return Ok(register);
            }
            catch (Exception ex)
            {
                return StatusCode(404, $"Erro do GetById(Controller): {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreatingRegistry([FromForm] Secretariat secret)
        {
            try
            {
                var register = _serviceCreate.Create(secret);
                return CreatedAtAction(nameof(GetByCpf), new { cpf = register.Cpf }, register);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro do Post(Controller): {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRegistry([FromForm] Guid id, Secretariat secret)
        {
            try
            {
                _serviceUpdate.Update(id, secret);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(404, $"Erro do Put(Controller): {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletedRegistry(Guid id)
        {
            try
            {
                _serviceDelete.Delete(id);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Erro do Delete(Controller): {ex.Message}");
            }
        }
    }
}
