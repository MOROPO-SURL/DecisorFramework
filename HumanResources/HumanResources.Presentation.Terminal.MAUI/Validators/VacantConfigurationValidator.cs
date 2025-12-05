using FluentValidation;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Validators;

public class VacantConfigurationValidator : AbstractValidator<Models.Page.Configuration.VacantConfigurationPageModel>
{
    public VacantConfigurationValidator()
    {
        RuleFor(model => model.WorkPosition).NotNull();

        RuleFor(model => model.SalaryStandard).NotNull();
    }
}
