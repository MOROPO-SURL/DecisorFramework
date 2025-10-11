namespace MOROPO.Framework.Decisor.Domain.Interop.API.Connect.Clients
{
    public class PropertiesAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.Property, System.Guid, Common.Models.Input.PropertyInputModel, Common.Models.Display.PropertyDisplayModel, Common.Models.Filter.PropertyFilterModel>
    {
        public PropertiesAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/domain/properties";
    }
}
