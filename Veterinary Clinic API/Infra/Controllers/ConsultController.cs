using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veterinary_Clinic_API.App.Mapping.Models.InputModels;
using Veterinary_Clinic_API.App.Mapping.Models.ViewModels;
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
        private readonly IMapper _mapper;

        public ConsultController(ICreateConsult serviceCreate, IDeleteConsult serviceDelete, IGetConsult serviceGet, IUpdateConsult serviceUpdate, IMapper mapper)
        {
            _serviceCreate = serviceCreate;
            _serviceDelete = serviceDelete;
            _serviceGet = serviceGet;
            _serviceUpdate = serviceUpdate;
            _mapper = mapper;
        }


        [HttpGet("FindConsult")]
        public IActionResult GetAll()
        {
            try
            {
                var allRegistration = _serviceGet.FindAll();

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
                var register = _serviceGet.FindByIdConsult(id);

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

                var register = _serviceCreate.Create(mapp);
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
                _serviceUpdate.Update(id, mapp);
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
