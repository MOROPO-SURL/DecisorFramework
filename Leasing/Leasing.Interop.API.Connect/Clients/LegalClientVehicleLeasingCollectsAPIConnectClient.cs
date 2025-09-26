namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Connect.Clients
{
    public class LegalClientVehicleLeasingCollectsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.LegalClientVehicleLeasingCollect, System.Guid, Common.Models.Input.LegalClientVehicleLeasingCollectInputModel, Common.Models.Display.LegalClientVehicleLeasingCollectDisplayModel, Common.Models.Filter.LegalClientVehicleLeasingCollectFilterModel>
    {
        public LegalClientVehicleLeasingCollectsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/leasing/legalclientvehicleleasingcollects";
    }
}
