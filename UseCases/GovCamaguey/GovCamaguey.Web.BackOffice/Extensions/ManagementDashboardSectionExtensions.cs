namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Extensions
{
    public static class ManagementDashboardSectionExtensions
    {
        public static Microsoft.AspNetCore.Html.HtmlString ToIconographyHtmlString(this Framework.Guama.Core.Presentation.Web.Backend.Models.View.ManagementDashboardSectionViewModel target)
        {
            if (target.Controller == "users") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-account");

            if (target.Controller == "roles") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-account-group");

            if (target.Controller == "traces") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-foot-print");

            if (target.Controller == "apikeys") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-key");

            if (target.Controller == "countries") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-flag");

            if (target.Controller == "states") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-sign-direction");

            if (target.Controller == "municipalities") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-city");

            if (target.Controller == "regions") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-earth-box");

            if (target.Controller == "unitmeasurements") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-scale");

            return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-toy-brick-outline");
        }
    }
}
