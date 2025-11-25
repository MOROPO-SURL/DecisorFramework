namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Connect.Clients
{
    public class SampleReceptionLabelsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.SampleReceptionLabel, System.Guid, Common.Models.Input.SampleReceptionLabelInputModel, Common.Models.Display.SampleReceptionLabelDisplayModel, Common.Models.Filter.SampleReceptionLabelFilterModel>
    {
        public SampleReceptionLabelsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/lab/samplereceptionlabels";
    }
}