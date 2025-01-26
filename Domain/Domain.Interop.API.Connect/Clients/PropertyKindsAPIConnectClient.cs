namespace MOROPO.Framework.Decisor.Domain.Interop.API.Connect.Clients
{
    public class PropertyKindsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityConsultAPIConnectClient<Persistence.Entities.PropertyKind, System.Guid, Common.Models.Display.PropertyKindDisplayModel>
    {
        public PropertyKindsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/domain/propertykinds";
    }
}