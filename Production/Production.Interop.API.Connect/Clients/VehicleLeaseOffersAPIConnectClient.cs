namespace MOROPO.Framework.Decisor.Production.Interop.API.Connect.Clients
{
    public class VehicleLeaseOffersAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.VehicleLeaseOffer, System.Guid, Common.Models.Input.VehicleLeaseOfferInputModel, Common.Models.Display.VehicleLeaseOfferDisplayModel, Common.Models.Filter.VehicleLeaseOfferFilterModel>
    {
        public VehicleLeaseOffersAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/production/vehicleleaseoffers";
    }
}