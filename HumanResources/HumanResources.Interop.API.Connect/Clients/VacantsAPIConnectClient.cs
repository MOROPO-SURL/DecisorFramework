namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Connect.Clients
{
    public class VacantsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.Vacant, System.Guid, Common.Models.Input.VacantInputModel, Common.Models.Display.VacantDisplayModel>
    {
        public VacantsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/hhrr/vacants";
    }
}
