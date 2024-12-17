namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Connect.Controllers
{
    public class ProvisionableServicesAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityManagementFilteredAPIConnectClient<Persistence.Entities.ProvisionableService, System.Guid, Common.Models.Input.ProvisionableServiceInputModel, Common.Models.Display.ProvisionableServiceDisplayModel, Common.Models.Filter.ProvisionableServiceFilterModel>
	{
        public ProvisionableServicesAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/commercial/provisionableservices";
    }
}

