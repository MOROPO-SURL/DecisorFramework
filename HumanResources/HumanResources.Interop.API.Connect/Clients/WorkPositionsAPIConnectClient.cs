namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Connect.Clients
{
    public class WorkPositionsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.WorkPosition, System.Guid, Common.Models.Input.WorkPositionInputModel, Common.Models.Display.WorkPositionDisplayModel, Common.Models.Filter.WorkPositionFilterModel>
    {
        public WorkPositionsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/hhrr/workpositions";
    }
}
