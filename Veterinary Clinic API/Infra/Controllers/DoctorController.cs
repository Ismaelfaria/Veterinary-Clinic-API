using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Veterinary_Clinic_API.App.Mapping.Models.InputModels;
using Veterinary_Clinic_API.App.Mapping.Models.ViewModels;
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.Infra.Controllers
{
    [Authorize(Roles = "Adm")]
    [Route("api/Doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctor _serviceDoctor;
        private readonly IMapper _mapper;

        public DoctorController(IDoctor serviceDoctor, IMapper mapper)
        {
            _serviceDoctor = serviceDoctor;
            _mapper = mapper;
        }



        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var allRegistration = _serviceDoctor.FindAll();

                var mapp = _mapper.Map<List<ViewDoctor>>(allRegistration);

                return Ok(mapp);
            }
            catch (Exception ex)
            {
                return StatusCode(404, $"Erro do GetAll(Controller): {ex.Message}");
            }
        }
        [HttpGet("{registro}")]
        public IActionResult GetByRegister(int registro)
        {
            try
            {
                var allRegistration = _serviceDoctor.FindByRegister(registro);

                var mapp = _mapper.Map<ViewDoctor>(allRegistration);

                return Ok(mapp);
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
                var register = _serviceDoctor.FindByUserName(name);

                var mapp = _mapper.Map<ViewDoctor>(register);

                return Ok(mapp);
            }
            catch (Exception ex)
            {
                return StatusCode(404, $"Erro do GetById(Controller): {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreatingRegistry([FromForm] InputDoctor doctor)
        {
            try
            {
                var mapp = _mapper.Map<Doctor>(doctor);

                var register = _serviceDoctor.Create(mapp);
                return CreatedAtAction(nameof(GetByRegister), new { registro = register.DoctorRegistration }, register);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro do Post(Controller): {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRegistry([FromForm] Guid id, InputDoctor doctor)
        {
            try
            {
                var mapp = _mapper.Map<Doctor>(doctor);

                _serviceDoctor.Update(id, mapp);
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
                _serviceDoctor.Delete(id);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Erro do Delete(Controller): {ex.Message}");
            }
        }
    }
}
