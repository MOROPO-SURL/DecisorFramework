using FluentValidation;

namespace MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Validators
{
    public class SettingValidator : AbstractValidator<Models.Page.SettingPageModel>
    {
        public SettingValidator()
        {
            RuleFor(model => model.ProxyServerAddress).Must((model, value) =>
            {
                if (!model.UseProxyServer) return true;

                return string.IsNullOrEmpty(value);
            });

            RuleFor(model => model.ProxyUsername).Must((model, value) =>
            {
                if (!model.UseProxyAuthentication) return true;

                return string.IsNullOrEmpty(value);
            });

            RuleFor(model => model.ProxyPassword).Must((model, value) =>
            {
                if (!model.UseProxyAuthentication) return true;

                return string.IsNullOrEmpty(value);
            });
        }
    }
}
