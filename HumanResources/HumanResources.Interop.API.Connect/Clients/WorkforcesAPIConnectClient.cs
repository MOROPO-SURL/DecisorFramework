namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Connect.Clients
{
    public class WorkforcesAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.Workforce, System.Guid, Common.Models.Input.WorkforceInputModel, Common.Models.Display.WorkforceDisplayModel, Common.Models.Filter.WorkforceFilterModel>
    {
        public WorkforcesAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/hhrr/workforces";
    }
}
