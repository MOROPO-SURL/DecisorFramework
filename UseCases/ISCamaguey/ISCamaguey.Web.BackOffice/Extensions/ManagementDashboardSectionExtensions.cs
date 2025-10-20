namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Extensions
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

            if (target.Controller == "legalbusinesskinds") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-bank");

            if (target.Controller == "legalproviders" || target.Controller == "legalclients") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-domain");

            if (target.Controller == "naturalbusinesskinds") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-account-tie-outline");

            if (target.Controller == "naturalproviders" || target.Controller == "naturalclients") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-account-tie");

            if (target.Controller == "employees") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-account-badge-horizontal");

            if (target.Controller == "colaborators") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-account-heart");

            if (target.Controller == "warehouses") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-warehouse");

            if (target.Controller == "products") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-package-variant-closed");

            if (target.Controller == "unitmeasurements") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-scale");

            if (target.Controller == "receptions") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-package-down");

            if (target.Controller == "departures") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-package-up");

            if (target.Controller == "purchaseplans") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-truck-fast");

            if (target.Controller == "purchases") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-truck-check");

            if (target.Controller == "purchasezones") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-dolly");

            if (target.Controller == "purchasespents") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-cash-usd-outline");

            if (target.Controller == "productionroles") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-clipboard-account");

            if (target.Controller == "elaborations") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-flask");

            if (target.Controller == "productions") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-cogs");

            if (target.Controller == "productionplans") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-clipboard-text");

            if (target.Controller == "remunerations") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-account-cash");

            if (target.Controller == "incomes") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-cash-plus");

            if (target.Controller == "payments") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-cash-minus");

            if (target.Controller == "refunds") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-cash-refund");

            if (target.Controller == "cachings") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-cash-register");

            if (target.Controller == "bankinputs") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-bank-transfer-in");

            if (target.Controller == "bankoutputs") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-bank-transfer-out");

            if (target.Controller == "recashes") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-credit-card-refund-outline");

            if (target.Controller == "nomns") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-credit-card-plus-outline");

            if (target.Controller == "advances") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-cash-multiple");

            if (target.Controller == "backs") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-cash-multiple mdi-flip-v");

            if (target.Controller == "shops") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-storefront");

            if (target.Controller == "teams") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-account-group-outline");

            if (target.Controller == "sales") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-point-of-sale");

            if (target.Controller == "bankagencies") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-bank");

            if (target.Controller == "bankbranches") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-bank-transfer");

            if (target.Controller == "bankaccounts") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-home-currency-usd");

            if (target.Controller == "currencies") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-square-inc-cash");

            if (target.Controller == "bankdebitcards") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-credit-card-outline");

            if (target.Controller == "costcenters") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-finance");

            if (target.Controller == "structurekinds") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-graph-outline");

            if (target.Controller == "propertykinds") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-home-city-outline");

            if (target.Controller == "vehicleenginekinds") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-engine");

            if (target.Controller == "vehiclekinds") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-bus-alert");

            if (target.Controller == "paymentterms") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-calendar-clock");

            if (target.Controller == "formingservices") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-teach");

            if (target.Controller == "plans") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-clipboard-text");

            if (target.Controller == "elavorations") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-cogs");

            if (target.Controller == "nationalnorms") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-octagram");

            if (target.Controller == "certificates") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-certificate");

            if (target.Controller == "floorstudyservices") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-sprout");

            if (target.Controller == "workgroups") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-account-supervisor-circle");

            if (target.Controller == "testhandlings") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-beaker-check");

            if (target.Controller == "testreceptions") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-beaker-alert");

            if (target.Controller == "technicals") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-microscope");

            if (target.Controller == "internationalnorms") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-check-decagram");

            if (target.Controller == "qualitychecks") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-clipboard-check");

            if (target.Controller == "categories") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-star-four-points");

            if (target.Controller == "releases") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-file-chart");

            if (target.Controller == "labtestservices") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-beaker-question");

            if (target.Controller == "propousals") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-lightbulb-on");

            if (target.Controller == "schoolings") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-school");

            if (target.Controller == "workpositionkinds") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-worker");

            if (target.Controller == "achivements") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-trophy-award");

            if (target.Controller == "achivements") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-podium");

            if (target.Controller == "publishes") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-post");

            if (target.Controller == "projects") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-folder-open");

            if (target.Controller == "ctihits") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-file-star");

            if (target.Controller == "ctihitintroductions") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-star-circle");

            if (target.Controller == "ctihitkinds") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-playlist-star");

            if (target.Controller == "sponsors") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-offer");

            if (target.Controller == "programs") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-city-variant");

            if (target.Controller == "researpartners") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-domain");

            if (target.Controller == "researchers") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-account-tie");

            if (target.Controller == "serviceorders") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-layers-triple");

            if (target.Controller == "samplekinds") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-beaker-outline");

            if (target.Controller == "researchercategories") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-flask-outline");

            if (target.Controller == "teachingcategories") return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-google-classroom");

            return new Microsoft.AspNetCore.Html.HtmlString("mdi mdi-toy-brick-outline");
        }
    }
}
