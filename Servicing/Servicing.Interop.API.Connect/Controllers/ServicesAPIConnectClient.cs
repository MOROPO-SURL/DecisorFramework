namespace MOROPO.Framework.Decisor.Servicing.Interop.API.Connect.Controllers
{
	public class ServicesAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityManagementFilteredAPIConnectClient<Persistence.Entities.Service, System.Guid, Common.Models.Input.ServiceInputModel, Common.Models.Display.ServiceDisplayModel, Common.Models.Filter.ServiceFilterModel>
	{
        public ServicesAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/services";
    }
}

