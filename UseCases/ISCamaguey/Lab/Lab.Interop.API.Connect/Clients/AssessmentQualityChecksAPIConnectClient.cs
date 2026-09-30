namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Connect.Clients
{
    public sealed class AssessmentQualityChecksAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.AssessmentQualityCheck, System.Guid, Common.Models.Input.AssessmentQualityCheckInputModel, Common.Models.Display.AssessmentQualityCheckDisplayModel, Common.Models.Filter.AssessmentQualityCheckFilterModel>
    {
        public AssessmentQualityChecksAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/lab/assessmentqualitychecks";
    }
}