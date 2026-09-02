namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Connect.Clients
{
    public class ResearchSamplesAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.ResearchSample, System.Guid, Common.Models.Input.ResearchSampleInputModel, Common.Models.Display.ResearchSampleDisplayModel, Common.Models.Filter.CommonSampleFilterModel<Common.Models.Display.ResearchSampleDisplayModel, Persistence.Entities.ResearchSample>>
    {
        public ResearchSamplesAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/lab/researchsamples";
    }
}