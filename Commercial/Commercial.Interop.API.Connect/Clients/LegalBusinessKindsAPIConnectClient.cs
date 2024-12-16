namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Connect.Clients
{
    public class LegalBusinessKindsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityConsultAPIConnectClient<Persistence.Entities.LegalBusinessKind, System.Guid, Common.Models.Display.LegalBusinessKindDisplayModel>
    {
        public LegalBusinessKindsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/commercial/legalbusinesskinds";
    }
}
