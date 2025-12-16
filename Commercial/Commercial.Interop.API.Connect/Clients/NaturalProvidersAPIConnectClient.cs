namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Connect.Clients
{
    public class NaturalProvidersAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.NaturalProvider, System.Guid, Common.Models.Input.NaturalProviderInputModel, Common.Models.Display.NaturalProviderDisplayModel, Common.Models.Filter.NaturalProviderFilterModel>
    {
        public NaturalProvidersAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/commercial/naturalproviders";
    }
}