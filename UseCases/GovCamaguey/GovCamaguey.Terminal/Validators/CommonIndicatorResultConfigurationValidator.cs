using FluentValidation;
using MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Models.Page.Configuration;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Validators;

public sealed class CommonIndicatorResultConfigurationValidator : AbstractValidator<CommonIndicatorResultConfigurationPageModel>
{
    public CommonIndicatorResultConfigurationValidator()
    {
        RuleFor(model => model.Description)
            .MaximumLength(2048)
            .WithName("Descripción");
    }
}
