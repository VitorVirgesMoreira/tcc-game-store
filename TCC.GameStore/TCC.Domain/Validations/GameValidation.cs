using FluentValidation;
using TCC.GameStore.Domain.Entities;

namespace TCC.GameStore.Domain.Validations
{
    public class GameValidation : AbstractValidator<Game>
    {
        public GameValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O nome deve ser informado.")
                .MaximumLength(100).WithMessage("O nome deve conter no máximo 100 caracteres.");

            RuleFor(x => x.Developer)
                .NotEmpty().WithMessage("A desenvolvedora deve ser informada.")
                .MaximumLength(100).WithMessage("O nome da desenvolvedora deve conter no máximo 100 caracteres.");

            RuleFor(d => d.DateLaunch)
                .NotEmpty().WithMessage("A data de entrega deve ser informada.");

            RuleFor(d => d.Price)
                .NotEmpty().WithMessage("O preço deve ser informado.");
        }
    }
}
