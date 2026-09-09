namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Connect.Clients
{
    public class ProgramKindsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEnableableEntityConsultAPIConnectClient<Persistence.Entities.ProgramKind, System.Guid, Common.Models.Display.ProgramKindDisplayModel>
    {
        public ProgramKindsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/idi/programkinds";
    }
}