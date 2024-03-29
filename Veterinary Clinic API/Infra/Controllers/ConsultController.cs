using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Veterinary_Clinic_API.App.Mapping.Models.InputModels;
using Veterinary_Clinic_API.App.Mapping.Models.ViewModels;
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.Infra.Controllers
{
    [Authorize(Roles = "Doutor, Adm")]
    [Route("api/Consult")]
    [ApiController]
    public class ConsultController : ControllerBase
    {
        private readonly IConsult _serviceConsult;
        private readonly IMapper _mapper;

        public ConsultController(IConsult serviceConsult, IMapper mapper)
        {
            _serviceConsult = serviceConsult;
            _mapper = mapper;
        }


        [HttpGet("FindConsult")]
        public IActionResult GetAll()
        {
            try
            {
                var allRegistration = _serviceConsult.FindAll();

                var mapp = _mapper.Map<List<ViewConsultation>>(allRegistration);

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
                var register = _serviceConsult.FindByIdConsult(id);

                var mapp = _mapper.Map<ViewConsultation>(register);

                return Ok(mapp);
            }
            catch (Exception ex)
            {
                return StatusCode(404, $"Erro do GetById(Controller): {ex.Message}");
            }
        }

        [HttpPost("MakeConsult")]
        public IActionResult MakeConsultation([FromForm] InputConsultation consult)
        {
            try
            {
                var mapp = _mapper.Map<Consultation>(consult);

                var register = _serviceConsult.Create(mapp);
                return CreatedAtAction(nameof(GetById), new { id = register.IdConsultation }, register);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro do Post(Controller): {ex.Message}");
            }
        }

        [HttpPut("UpdateConsult/{id}")]
        public IActionResult UpdateRegistry([FromForm] Guid id, InputConsultation consult)
        {
            try
            {
                var mapp = _mapper.Map<Consultation>(consult);
                _serviceConsult.Update(id, mapp);
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
                _serviceConsult.DeleteAndTerminated(id);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Erro do Delete(Controller): {ex.Message}");
            }
        }
    }
}
