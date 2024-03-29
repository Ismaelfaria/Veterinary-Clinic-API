using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veterinary_Clinic_API.App.Mapping.Models.InputModels;
using Veterinary_Clinic_API.App.Mapping.Models.ViewModels;
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.Infra.Controllers
{
    [Authorize(Roles = "Doutor, Adm")]
    [Route("api/SecretariatHome")]
    [ApiController]
    public class SecretariaController : ControllerBase
    {
        private readonly ISecretariat _serviceSecre;
        private readonly IMapper _mapper;

        public SecretariaController(ISecretariat serviceSecre, IMapper mapper)
        {
            _serviceSecre = serviceSecre;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var allRegistration = _serviceSecre.FindAll();

                var mapp = _mapper.Map<List<ViewSecretariat>>(allRegistration);

                return Ok(mapp);
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
                var Registration = _serviceSecre.FindByCpf(cpf);

                var mapp = _mapper.Map<ViewDoctor>(Registration);

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
                var register = _serviceSecre.FindByUserName(name);

                var mapp = _mapper.Map<ViewDoctor>(register);

                return Ok(mapp);
            }
            catch (Exception ex)
            {
                return StatusCode(404, $"Erro do GetById(Controller): {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreatingRegistry([FromForm] InputSecretariat secret)
        {
            try
            {
                var mapp = _mapper.Map<Secretariat>(secret);

                var register = _serviceSecre.Create(mapp);
                return CreatedAtAction(nameof(GetByCpf), new { cpf = register.Cpf }, register);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro do Post(Controller): {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRegistry([FromForm] Guid id, InputSecretariat secret)
        {
            try
            {
                var mapp = _mapper.Map<Secretariat>(secret);

                _serviceSecre.Update(id, mapp);
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
                _serviceSecre.Delete(id);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Erro do Delete(Controller): {ex.Message}");
            }
        }
    }
}
