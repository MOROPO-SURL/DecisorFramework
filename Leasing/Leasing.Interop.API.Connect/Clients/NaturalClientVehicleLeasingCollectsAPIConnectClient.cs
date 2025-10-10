namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Connect.Clients
{
    public class NaturalClientVehicleLeasingCollectsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.NaturalClientVehicleLeasingCollect, System.Guid, Common.Models.Input.NaturalClientVehicleLeasingCollectInputModel, Common.Models.Display.NaturalClientVehicleLeasingCollectDisplayModel, Common.Models.Filter.NaturalClientVehicleLeasingCollectFilterModel>
    {
        public NaturalClientVehicleLeasingCollectsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/leasing/naturalclientvehicleleasingcollects";
    }
}