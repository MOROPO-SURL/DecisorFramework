using FluentValidation;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Validators
{
    public class UnitMeasurementConfigurationValidator : AbstractValidator<Models.Page.Configuration.UnitMeasurementConfigurationPageModel>
    {
        public UnitMeasurementConfigurationValidator()
        {
            RuleFor(model => model.Name).NotNull().NotEmpty().WithName("Nombre");

            RuleFor(model => model.Symbol).NotNull().NotEmpty().WithName("Símbolo");
        }
    }
}
