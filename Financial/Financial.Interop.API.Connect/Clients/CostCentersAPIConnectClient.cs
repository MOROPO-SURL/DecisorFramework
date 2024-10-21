namespace MOROPO.Framework.Decisor.Financial.Interop.API.Connect.Clients
{
    public class CostCentersAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.CostCenter, System.Guid, Common.Models.Input.CostCenterInputModel, Common.Models.Display.CostCenterDisplayModel>
    {
        public CostCentersAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/costcenters";
    }
}

