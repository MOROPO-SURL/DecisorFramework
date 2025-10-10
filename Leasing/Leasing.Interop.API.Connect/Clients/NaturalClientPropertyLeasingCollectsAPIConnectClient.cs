namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Connect.Clients
{
    public class NaturalClientPropertyLeasingCollectsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.NaturalClientPropertyLeasingCollect, System.Guid, Common.Models.Input.NaturalClientPropertyLeasingCollectInputModel, Common.Models.Display.NaturalClientPropertyLeasingCollectDisplayModel, Common.Models.Filter.NaturalClientPropertyLeasingCollectFilterModel>
    {
        public NaturalClientPropertyLeasingCollectsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/leasing/naturalclientpropertyleasingcollects";
    }
}
