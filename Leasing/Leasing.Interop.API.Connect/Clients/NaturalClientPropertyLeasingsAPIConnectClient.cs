namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Connect.Clients
{
    public class NaturalClientPropertyLeasingsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.NaturalClientPropertyLeasing, System.Guid, Common.Models.Input.NaturalClientPropertyLeasingInputModel, Common.Models.Display.NaturalClientPropertyLeasingDisplayModel>
    {
        public NaturalClientPropertyLeasingsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/leasing/naturalclientpropertyleasings";
    }
}
