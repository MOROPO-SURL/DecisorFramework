using System.Linq;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Connect.Clients
{
    public class ResultsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityManagementFilteredAPIConnectClient<Persistence.Entities.Result, long, Common.Models.Input.ResultInputModel, Common.Models.Display.ResultDisplayModel, Common.Models.Filter.ResultFilterModel>
    {
        public ResultsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/governance/results";

        public System.Threading.Tasks.Task<Common.Models.Display.ResultDisplayModel[]> GetLastsByIndicators(Common.Models.Display.IndicatorDisplayModel[] indicators)
        {
            return httpClientHelperProvider.HttpClientHelper.PostAsync<System.Guid[], Common.Models.Display.ResultDisplayModel[]>($"{TargetController}/lasts/by/indicators", indicators.Select(model => model.Id).ToArray());
        }
    }
}
