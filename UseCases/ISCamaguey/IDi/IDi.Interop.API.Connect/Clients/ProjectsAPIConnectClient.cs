namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Connect.Clients
{
    public class ProjectsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.Project, System.Guid, Common.Models.Input.ProjectInputModel, Common.Models.Display.ProjectDisplayModel, Common.Models.Filter.ProjectFilterModel>
    {
        public ProjectsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/idi/projects";
    }
}