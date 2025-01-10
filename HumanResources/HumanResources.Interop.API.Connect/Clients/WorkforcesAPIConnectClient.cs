namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Connect.Clients
{
    public class WorkforcesAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.Workforce, System.Guid, Common.Models.Input.WorkforceInputModel, Common.Models.Display.WorkforceDisplayModel>
    {
        public WorkforcesAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/hhrr/workforces";
    }
}
