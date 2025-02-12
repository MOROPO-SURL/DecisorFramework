namespace MOROPO.Framework.Decisor.Domain.Interop.API.Connect.Clients
{
    public class TreeStructuresAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEnableableEntityConsultAPIConnectClient<Persistence.Entities.Structure, System.Guid, Common.Models.Display.StructureTreeDisplayModel>
    {
        public TreeStructuresAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/domain/structures/tree";
    }
}
