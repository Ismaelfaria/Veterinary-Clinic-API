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
    [Authorize(Roles = "Doutor")]
    [Route("api/Consult")]
    [ApiController]
    public class ConsultController : ControllerBase
    {
        private readonly ICreateConsult _serviceCreate;
        private readonly IDeleteConsult _serviceDelete;
        private readonly IGetConsult _serviceGet;
        private readonly IUpdateConsult _serviceUpdate;

        public ConsultController(ICreateConsult serviceCreate, IDeleteConsult serviceDelete, IGetConsult serviceGet, IUpdateConsult serviceUpdate)
        {
            _serviceCreate = serviceCreate;
            _serviceDelete = serviceDelete;
            _serviceGet = serviceGet;
            _serviceUpdate = serviceUpdate;
        }


        [HttpGet("FindConsult")]
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

        [HttpGet("FindConsult/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var register = _serviceGet.FindByIdConsult(id);
                return Ok(register);
            }
            catch (Exception ex)
            {
                return StatusCode(404, $"Erro do GetById(Controller): {ex.Message}");
            }
        }

        [HttpPost("MakeConsult")]
        public IActionResult MakeConsultation([FromForm] Consultation consult)
        {
            try
            {
                var register = _serviceCreate.Create(consult);
                return CreatedAtAction(nameof(GetById), new { id = register.IdConsultation }, register);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro do Post(Controller): {ex.Message}");
            }
        }

        [HttpPut("UpdateConsult/{id}")]
        public IActionResult UpdateRegistry([FromForm] Guid id, Consultation consult)
        {
            try
            {
                _serviceUpdate.Update(id, consult);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(404, $"Erro do Put(Controller): {ex.Message}");
            }
        }

        [HttpDelete("DeleteConsult/{id}")]
        public IActionResult EndConsultation(Guid id)
        {
            try
            {
                _serviceDelete.DeleteAndTerminated(id);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Erro do Delete(Controller): {ex.Message}");
            }
        }
    }
}
