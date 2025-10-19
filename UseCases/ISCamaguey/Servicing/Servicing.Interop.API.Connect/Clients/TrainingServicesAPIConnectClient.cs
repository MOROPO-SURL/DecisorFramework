namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Connect.Clients
{
    public class TrainingServicesAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.TrainingService, System.Guid, Common.Models.Input.TrainingServiceInputModel, Common.Models.Display.TrainingServiceDisplayModel, Common.Models.Filter.TrainingServiceFilterModel>
    {
        public TrainingServicesAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/servicing/trainingservices";
    }
}
