using Entities.Concrete.TableModels;
using FluentValidation;

namespace Business.Validations
{
    public class AboutValidation : AbstractValidator<About>
    {
        public AboutValidation()
        {
            RuleFor(x => x.Description)
                .MinimumLength(3)
                .WithMessage("3 simvoldan az daxil edilə bilməz")
                //.Must(x=>x.StartsWith("a"))
                //.WithMessage("Cumle mutleq a ile baslamalidir")
                .MaximumLength(2000)
                .WithMessage("2000 simvoldan artıq ola bilməz")
                .NotEmpty()
                .WithMessage("Boş ola bilməz");
        }
    }
}
