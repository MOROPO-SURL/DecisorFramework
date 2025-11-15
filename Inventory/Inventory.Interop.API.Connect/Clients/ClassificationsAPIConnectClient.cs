namespace MOROPO.Framework.Decisor.Inventory.Interop.API.Connect.Clients
{
    public class ClassificationsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityConsultFilteredAPIConnectClient<Persistence.Entities.Classification, System.Guid, Common.Models.Display.ClassificationDisplayModel, Common.Models.Filter.ClassificationFilterModel>
    {
        public ClassificationsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/inventory/classifications";
    }
}
