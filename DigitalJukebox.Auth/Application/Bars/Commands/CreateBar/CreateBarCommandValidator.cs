using FluentValidation;
using Application.Bars.Commands.CreateBar;

namespace Application.Bars.Commands.CreateBar
{
    public class CreateBarCommandValidator : AbstractValidator<CreateBarcommand>
    {
        public CreateBarCommandValidator()
        {
            RuleFor(b => b.Name)
                .MaximumLength(150)
                .NotEmpty();
        }
    }
}