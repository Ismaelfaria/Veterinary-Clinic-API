using FluentValidation;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.Validator
{
    public class ValidatorClient : AbstractValidator<Client>
    {
        public ValidatorClient()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("Informe o seu nome");

            RuleFor(c => c.LastName)
               .NotEmpty().WithMessage("Informe o seu SobreNome");

            RuleFor(c => c.Cpf)
               .NotEmpty().WithMessage("Informe o seu CPF");

            RuleFor(c => c.ContactNumber)
               .NotEmpty().WithMessage("Informe o seu numero de contato");

            RuleFor(c => c.TypeOfAnimal)
               .NotEmpty().WithMessage("Informe o seu animal");
        }
    }
}
