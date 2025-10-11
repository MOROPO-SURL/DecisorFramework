namespace MOROPO.Framework.Decisor.Domain.Interop.API.Connect.Clients
{
    public class StructureKindsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityConsultAPIConnectClient<Persistence.Entities.StructureKind, System.Guid, Common.Models.Display.StructureKindDisplayModel>
    {
        public StructureKindsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/domain/structurekinds";
    }
}
