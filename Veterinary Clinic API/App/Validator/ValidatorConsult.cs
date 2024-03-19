using FluentValidation;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.Validator
{
    public class ValidatorConsult : AbstractValidator<Consultation>
    {
        public ValidatorConsult()
        {
            RuleFor(d => d.CpfClient)
               .NotEmpty().WithMessage("O campo nome não pode estar vazio");

            RuleFor(d => d.Symptoms)
               .NotEmpty().WithMessage("O campo senha não pode estar vazio");

            RuleFor(d => d.RegisterDoctor)
               .NotEmpty().WithMessage("O campo contato não pode estar vazio");
        }
    }
}
