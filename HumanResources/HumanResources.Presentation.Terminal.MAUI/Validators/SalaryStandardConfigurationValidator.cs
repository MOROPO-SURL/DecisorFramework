using FluentValidation;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Validators;

public class SalaryStandardConfigurationValidator : AbstractValidator<Models.Page.Configuration.SalaryStandardConfigurationPageModel>
{
    public SalaryStandardConfigurationValidator()
    {
        RuleFor(model => model.Name).NotEmpty().WithName("Nombre");
    }
}
