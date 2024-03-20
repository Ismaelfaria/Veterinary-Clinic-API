using FluentValidation;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.Validator
{
    public class ValidatorDoctor:AbstractValidator<Doctor>
    {

        public ValidatorDoctor()
        {
            RuleFor(d => d.UserName)
                .NotEmpty().WithMessage("O campo nome não pode estar vazio");

            RuleFor(d => d.Password)
               .NotEmpty().WithMessage("O campo senha não pode estar vazio");

            RuleFor(d => d.ContactNumber)
               .NotEmpty().WithMessage("O campo contato não pode estar vazio");

            RuleFor(d => d.Cpf)
               .NotEmpty().WithMessage("O campo cpf não pode estar vazio");

            RuleFor(d => d.DoctorRegistration)
               .NotEmpty().WithMessage("O campo registro não pode estar vazio");

        }
    }
}
