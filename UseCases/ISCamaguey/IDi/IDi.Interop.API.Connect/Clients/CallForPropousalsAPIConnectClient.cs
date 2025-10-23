namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Connect.Clients
{
    public class CallForPropousalsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.CallForPropousal, System.Guid, Common.Models.Input.CallForPropousalInputModel, Common.Models.Display.CallForPropousalDisplayModel, Common.Models.Filter.CallForPropousalFilterModel>
    {
        public CallForPropousalsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/idi/callforpropousals";
    }
}
