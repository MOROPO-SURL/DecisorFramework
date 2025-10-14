namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Connect.Clients
{
    public class WorkPositionsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.WorkPosition, System.Guid, Common.Models.Input.WorkPositionInputModel, Common.Models.Display.WorkPositionDisplayModel>
    {
        public WorkPositionsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/hhrr/workpositions";
    }
}
