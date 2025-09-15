using FluentValidation;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Validators
{
    public class UnitMeasurementConfigurationValidator : AbstractValidator<Models.Page.Configuration.UnitMeasurementConfigurationPageModel>
    {
        public UnitMeasurementConfigurationValidator()
        {
            RuleFor(model => model.Name)
                .NotNull();

            RuleFor(model => model.Symbol)
                .NotNull();
        }
    }
}
