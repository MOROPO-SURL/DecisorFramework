namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Connect.Clients
{
    public class LegalClientTrainingServiceExecutionsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.LegalClientTrainingServiceExecution, System.Guid, Common.Models.Input.LegalClientTrainingServiceExecutionInputModel, Common.Models.Display.LegalClientTrainingServiceExecutionDisplayModel, Common.Models.Filter.LegalClientTrainingServiceExecutionFilterModel>
    {
        public LegalClientTrainingServiceExecutionsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/servicing/legalclienttrainingserviceexecutions";
    }
}