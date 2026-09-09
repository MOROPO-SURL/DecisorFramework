namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Connect.Clients
{
    public sealed class WorkPlansAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementAPIConnectClient<Persistence.Entities.WorkPlan, System.Guid, Common.Models.Input.WorkPlanInputModel, Common.Models.Display.WorkPlanDisplayModel>
    {
        public WorkPlansAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/lab/workplans";
    }
}