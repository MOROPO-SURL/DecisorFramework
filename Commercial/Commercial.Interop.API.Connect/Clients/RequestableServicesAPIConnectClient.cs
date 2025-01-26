namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Connect.Clients
{
    public class RequestableServicesAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityManagementFilteredAPIConnectClient<Persistence.Entities.RequestableService, System.Guid, Common.Models.Input.RequestableServiceInputModel, Common.Models.Display.RequestableServiceDisplayModel, Common.Models.Filter.RequestableServiceFilterModel>
    {
        public RequestableServicesAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/commercial/requestableservices";
    }
}
