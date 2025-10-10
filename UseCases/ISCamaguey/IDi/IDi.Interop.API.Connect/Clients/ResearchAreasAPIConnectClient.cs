namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Connect.Clients
{
    public class ResearchAreasAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.ResearchArea, System.Guid, Common.Models.Input.ResearchAreaInputModel, Common.Models.Display.ResearchAreaDisplayModel, Common.Models.Filter.ResearchAreaFilterModel>
    {
        public ResearchAreasAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/case/idi/researchareas";
    }
}
