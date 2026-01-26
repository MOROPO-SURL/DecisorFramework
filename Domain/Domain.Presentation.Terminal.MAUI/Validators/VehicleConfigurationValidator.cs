using FluentValidation;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Validators
{
    public class VehicleConfigurationValidator : AbstractValidator<Models.Page.Configuration.VehicleConfigurationPageModel>
    {
        public VehicleConfigurationValidator()
        {
            RuleFor(model => model.Brand).NotNull();

            RuleFor(model => model.Model).NotEmpty();

            RuleFor(model => model.Reference).NotEmpty();

            RuleFor(model => model.OperativeLicenceCode).NotEmpty();

            RuleFor(model => model.Kind).NotNull();

            RuleFor(model => model.EngineKind).NotNull();

            RuleFor(model => model.Plate).NotEmpty();

            RuleFor(model => model.BodyIdentifier).NotEmpty();

            RuleFor(model => model.EngineIdentifier).NotEmpty();

            RuleFor(model => model.SeatCount).NotNull().GreaterThan(0);

            RuleFor(model => model.Structure).NotNull();

            RuleFor(model => model.TechnicalAvailabilityIndex).NotNull().InclusiveBetween(1,100);

            RuleFor(model => model.TrafficCirculationIdentifier).NotEmpty();

            RuleFor(model => model.Year).NotNull().GreaterThan(1940);
        }
    }
}
