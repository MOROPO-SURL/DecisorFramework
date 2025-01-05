namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Connect.Clients
{
    public class VacantKindsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityConsultAPIConnectClient<Persistence.Entities.VacantKind, System.Guid, Common.Models.Display.VacantKindDisplayModel>
    {
        public VacantKindsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/hhrr/vacantkinds";
    }
}
