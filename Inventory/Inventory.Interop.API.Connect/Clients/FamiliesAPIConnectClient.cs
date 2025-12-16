namespace MOROPO.Framework.Decisor.Inventory.Interop.API.Connect.Clients
{
	public class FamiliesAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.Family, int, Common.Models.Input.FamilyInputModel, Common.Models.Display.FamilyDisplayModel, Common.Models.Filter.FamilyFilterModel>
    {
        public FamiliesAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/inventory/families";
    }
}