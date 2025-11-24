using FluentValidation;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.Validators;

public class LegalClientServicingContractConfigurationValidator : AbstractValidator<Models.Page.Configuration.LegalClientServicingContractConfigurationPageModel>
{
    public LegalClientServicingContractConfigurationValidator()
    {
        RuleFor(model => model.Index).GreaterThanOrEqualTo(1);

        RuleFor(model => model.DurationUnitCount).GreaterThanOrEqualTo(1);

        RuleFor(model => model.DurationUnitMeasureKind).NotNull();

        RuleFor(model => model.Objective).NotNull().NotEmpty();

        RuleFor(model => model.PaymentTerm).NotNull();

        RuleFor(model => model.Client).NotNull();

        RuleFor(model => model.BankAccount).NotNull();

        RuleFor(model => model.TrainingServices).Must((model, value) =>
        {
            if (model.GroundIntegralStudyServices.Any() || model.SampleAnalysisServices.Any()) return true;

            return value.Any();
        });

        RuleFor(model => model.SampleAnalysisServices).Must((model, value) =>
        {
            if (model.GroundIntegralStudyServices.Any() || model.TrainingServices.Any()) return true;

            return value.Any();
        });

        RuleFor(model => model.GroundIntegralStudyServices).Must((model, value) =>
        {
            if (model.TrainingServices.Any() || model.SampleAnalysisServices.Any()) return true;

            return value.Any();
        });
    }
}
