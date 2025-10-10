namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Connect.Clients
{
    public class WorkingGroupsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.WorkingGroup, System.Guid, Common.Models.Input.WorkingGroupInputModel, Common.Models.Display.WorkingGroupDisplayModel, Common.Models.Filter.WorkingGroupFilterModel>
    {
        public WorkingGroupsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/case/lab/workinggroups";
    }
}
