namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Connect.Clients
{
    public class ScientificTechnicalResultKindsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.ScientificTechnicalResultKind, System.Guid, Common.Models.Input.ScientificTechnicalResultKindInputModel, Common.Models.Display.ScientificTechnicalResultKindDisplayModel, Common.Models.Filter.ScientificTechnicalResultKindFilterModel>
    {
        public ScientificTechnicalResultKindsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/idi/scientifictechnicalresultkinds";
    }
}