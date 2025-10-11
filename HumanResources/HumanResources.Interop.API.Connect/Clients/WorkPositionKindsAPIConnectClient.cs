namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Connect.Clients
{
    public class WorkPositionKindsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityConsultAPIConnectClient<Persistence.Entities.WorkPositionKind, System.Guid, Common.Models.Display.WorkPositionKindDisplayModel>
    {
        public WorkPositionKindsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/hhrr/workpositionkinds";
    }
}
