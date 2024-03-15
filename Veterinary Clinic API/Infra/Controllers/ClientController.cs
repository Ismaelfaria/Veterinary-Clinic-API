using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.App.ServicesInterface.IDeleteService;
using Veterinary_Clinic_API.App.ServicesInterface.IGetService;
using Veterinary_Clinic_API.App.ServicesInterface.IUpdateService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.Infra.Controllers
{
    [Authorize(Roles = "Secretaria, Doutor")]
    [Route("api/ClientHome")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ICreateClient _serviceCreate;
        private readonly IDeleteClient _serviceDelete;
        private readonly IGetClient _serviceGet;
        private readonly IUpdateClient _serviceUpdate;

        public ClientController(ICreateClient serviceCreate, IDeleteClient serviceDelete, IGetClient serviceGet, IUpdateClient serviceUpdate)
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

        [HttpGet("{id}")]
        public IActionResult GetById(string name)
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

        [HttpGet("{cpf}")]
        public IActionResult GetByCpf(int cpf)
        {
            try
            {
                var register = _serviceGet.FindByCpf(cpf);
                return Ok(register);
            }
            catch (Exception ex)
            {
                return StatusCode(404, $"Erro do GetById(Controller): {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreatingRegistry([FromForm] Client client)
        {
            try
            {
                var register = _serviceCreate.Create(client);
                return CreatedAtAction(nameof(GetById), new { id = register.Id }, register);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro do Post(Controller): {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRegistry([FromForm] int cpf, Client client)
        {
            try
            {
                _serviceUpdate.Update(cpf, client);
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
