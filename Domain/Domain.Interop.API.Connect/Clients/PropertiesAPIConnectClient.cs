namespace MOROPO.Framework.Decisor.Domain.Interop.API.Connect.Clients
{
    public class PropertiesAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementAPIConnectClient<Persistence.Entities.Property, System.Guid, Common.Models.Input.PropertyInputModel, Common.Models.Display.PropertyDisplayModel>
    {
        public PropertiesAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/domain/properties";
    }
}
