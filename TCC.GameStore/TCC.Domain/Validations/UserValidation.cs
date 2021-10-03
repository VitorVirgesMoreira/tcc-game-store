using FluentValidation;
using TCC.GameStore.Domain.Entities;
using TCC.GameStore.Domain.Validations.ServiceValidation;

namespace TCC.GameStore.Domain.Validations
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O nome deve ser informado.")
                .MaximumLength(100).WithMessage("O nome deve conter no máximo 100 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O email deve ser informado.")
                .Must(x => x.IsValidEmail()).WithMessage("o email é inválido.")
                .MaximumLength(100).WithMessage("O email deve conter no máximo 100 caracteres.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("A senha deve ser informada.")
                .MaximumLength(20).WithMessage("A senha deve conter no máximo 20 caracteres.");

        }
    }
}
