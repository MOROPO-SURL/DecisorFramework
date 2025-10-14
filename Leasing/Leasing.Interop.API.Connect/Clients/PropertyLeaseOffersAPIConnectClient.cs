namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Connect.Clients
{
    public class PropertyLeaseOffersAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.PropertyLeaseOffer, System.Guid, Common.Models.Input.PropertyLeaseOfferInputModel, Common.Models.Display.PropertyLeaseOfferDisplayModel>
    {
        public PropertyLeaseOffersAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/leasing/propertyleaseoffers";
    }
}