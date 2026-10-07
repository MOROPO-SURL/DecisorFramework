using FluentValidation;
namespace MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Validators
{
    public class SettingValidator : AbstractValidator<Models.Page.SettingPageModel>
    {
        public SettingValidator()
        {
            RuleFor(model => model.ApiServerAddress)
                .NotEmpty()
                .WithName("Dirección del servidor API");

            RuleFor(model => model.ApiServerPort)
                .NotEmpty()
                .GreaterThan(0)
                .WithName("Puerto del servidor API");

            RuleFor(model => model.ProxyServerAddress).Must((model, value) =>
            {
                if (!model.UseProxyServer) return true;

                return !string.IsNullOrEmpty(value) && System.Uri.TryCreate(value, System.UriKind.Absolute, out System.Uri uriResult) && (uriResult.Scheme == System.Uri.UriSchemeHttp || uriResult.Scheme == System.Uri.UriSchemeHttps) && !uriResult.IsUnc;
            });

            RuleFor(model => model.ProxyUsername).Must((model, value) =>
            {
                if (!model.UseProxyAuthentication) return true;

                return !string.IsNullOrEmpty(value);
            });

            RuleFor(model => model.ProxyPassword).Must((model, value) =>
            {
                if (!model.UseProxyAuthentication) return true;

                return !string.IsNullOrEmpty(value);
            });
        }
    }
}
