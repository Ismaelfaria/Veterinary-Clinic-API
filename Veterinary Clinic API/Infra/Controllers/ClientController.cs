﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Veterinary_Clinic_API.App.Mapping.Models.InputModels;
using Veterinary_Clinic_API.App.Mapping.Models.ViewModels;
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.Infra.Controllers
{
    [Authorize(Roles = "Secretaria, Doutor, Adm")]
    [Route("api/ClientHome")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClient _serviceClient;
        private readonly IMapper _mapper;

        public ClientController(IClient serviceClient, IMapper mapper)
        {
            _serviceClient = serviceClient;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var allRegistration = _serviceClient.FindAll();

                var mapp = _mapper.Map<List<ViewClient>>(allRegistration);

                return Ok(mapp);
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
                var register = _serviceClient.FindByUserName(name);

                var mapp = _mapper.Map<ViewClient>(register);

                return Ok(mapp);
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
                var register = _serviceClient.FindByCpf(cpf);

                var mapp = _mapper.Map<ViewClient>(register);

                return Ok(mapp);
            }
            catch (Exception ex)
            {
                return StatusCode(404, $"Erro do GetById(Controller): {ex.Message}");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreatingRegistry([FromForm] InputClient client)
        {
            try
            {
                var mapp = _mapper.Map<Client>(client);

                var register = _serviceClient.Create(mapp);
                return CreatedAtAction(nameof(GetById), new { id = register.Id }, register);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro do Post(Controller): {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRegistry([FromForm] int cpf, InputClient client)
        {
            try
            {
                var mapp = _mapper.Map<Client>(client);

                _serviceClient.Update(cpf, mapp);
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
                _serviceClient.Delete(id);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Erro do Delete(Controller): {ex.Message}");
            }
        }
    }
}
