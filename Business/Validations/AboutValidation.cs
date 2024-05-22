using Business.BaseMessages;
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
                .WithMessage(UIMessages.GetMinLengthMessage(3,"Açıqlama"))
                .MaximumLength(2000)
                .WithMessage(UIMessages.GetMaxLengthMessage(2000,"Açıqlama"))
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Açıqlama"));
        }
    }
}
