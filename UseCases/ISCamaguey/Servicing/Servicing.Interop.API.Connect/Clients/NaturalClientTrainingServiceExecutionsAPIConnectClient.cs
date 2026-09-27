namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Connect.Clients
{
    public class NaturalClientTrainingServiceExecutionsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.NaturalClientTrainingServiceExecution, System.Guid, Common.Models.Input.NaturalClientTrainingServiceExecutionInputModel, Common.Models.Display.NaturalClientTrainingServiceExecutionDisplayModel, Common.Models.Filter.NaturalClientTrainingServiceExecutionFilterModel>
    {
        public NaturalClientTrainingServiceExecutionsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/servicing/naturalclienttrainingserviceexecutions";
    }
}