namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Connect.Clients
{
    public class VehicleLeaseOffersAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.VehicleLeaseOffer, System.Guid, Common.Models.Input.VehicleLeaseOfferInputModel, Common.Models.Display.VehicleLeaseOfferDisplayModel>
    {
        public VehicleLeaseOffersAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/leasing/vehicleleaseoffers";
    }
}