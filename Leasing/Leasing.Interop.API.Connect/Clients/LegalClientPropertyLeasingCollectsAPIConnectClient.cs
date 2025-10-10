namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Connect.Clients
{
    public class LegalClientPropertyLeasingCollectsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.LegalClientPropertyLeasingCollect, System.Guid, Common.Models.Input.LegalClientPropertyLeasingCollectInputModel, Common.Models.Display.LegalClientPropertyLeasingCollectDisplayModel, Common.Models.Filter.LegalClientPropertyLeasingCollectFilterModel>
    {
        public LegalClientPropertyLeasingCollectsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/leasing/legalclientpropertyleasingcollects";
    }
}
