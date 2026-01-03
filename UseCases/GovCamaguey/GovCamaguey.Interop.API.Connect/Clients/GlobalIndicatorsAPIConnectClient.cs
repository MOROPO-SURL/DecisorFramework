namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Connect.Clients
{
    public class GlobalIndicatorsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.GlobalIndicator, System.Guid, Common.Models.Input.GlobalIndicatorInputModel, Common.Models.Display.GlobalIndicatorDisplayModel, Common.Models.Filter.GlobalIndicatorFilterModel>
    {
        public GlobalIndicatorsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/governance/globalindicators";
    }
}