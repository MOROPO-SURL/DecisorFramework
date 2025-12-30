using System.Linq;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Connect.Clients
{
    public class ActionIndicatorResultsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityManagementFilteredAPIConnectClient<Persistence.Entities.ActionIndicatorResult, long, Common.Models.Input.ResultInputModel, Common.Models.Display.ResultDisplayModel, Common.Models.Filter.ResultFilterModel>
    {
        public ActionIndicatorResultsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/governance/actionindicatorresults";

        public System.Threading.Tasks.Task<Common.Models.Display.ResultDisplayModel[]> GetLastsByIndicators(Common.Models.Display.ActionIndicatorDisplayModel[] indicators)
        {
            return httpClientHelperProvider.HttpClientHelper.PostAsync<System.Guid[], Common.Models.Display.ResultDisplayModel[]>($"{TargetController}/lasts/by/indicators", indicators.Select(model => model.Id).ToArray());
        }
    }
}
