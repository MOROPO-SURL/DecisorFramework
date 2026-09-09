
using FluentValidation;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Validators
{
    public class KnowledgeAreaConfigurationValidator : AbstractValidator<Models.Page.Configuration.KnowledgeAreaConfigurationPageModel>
    {
        public KnowledgeAreaConfigurationValidator()
        {
            RuleFor(model => model.Name).NotNull().NotEmpty();
        }
    }
}
