namespace MOROPO.Framework.Decisor.Domain.Interop.API.Connect.Clients
{
    public class ParentalStructuresAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementAPIConnectClient<Persistence.Entities.Structure, System.Guid, Common.Models.Input.StructureInputModel, Common.Models.Display.StructureParentalDisplayModel>
    {
        public ParentalStructuresAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/domain/structures/parental";
    }
}
