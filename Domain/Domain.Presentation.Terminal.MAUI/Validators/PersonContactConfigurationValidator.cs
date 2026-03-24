using FluentValidation;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Validators
{
    public class PersonContactConfigurationValidator : AbstractValidator<Models.Page.Configuration.PersonContactConfigurationPageModel>
    {
        public PersonContactConfigurationValidator()
        {
            RuleFor(model => model.Name)
                .NotEmpty()
                .WithName("Nombre");
        }
    }
}