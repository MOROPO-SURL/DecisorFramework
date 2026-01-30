using FluentValidation;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Validators;

public class OrganizationalUnityConfigurationValidator : AbstractValidator<Models.Page.Configuration.OrganizationalUnityConfigurationPageModel>
{
    public OrganizationalUnityConfigurationValidator()
    {
        RuleFor(entity => entity.Name).NotEmpty().WithName("Nombre");
    }
}