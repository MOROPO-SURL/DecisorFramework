namespace MOROPO.Framework.Decisor.Core.Interop.API.Connect.Clients
{
    public class NaturalPersonalityKindsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityConsultAPIConnectClient<Persistence.Entities.NaturalBusinessKind, System.Guid, Common.Models.Display.NaturalBusinessKindDisplayModel>
    {
        public NaturalPersonalityKindsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/naturalbusinesskinds";
    }
}
