namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Connect.Clients
{
    public class AwardKindsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.AwardKind, System.Guid, Common.Models.Input.AwardKindInputModel, Common.Models.Display.AwardKindDisplayModel, Common.Models.Filter.AwardKindFilterModel>
    {
        public AwardKindsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/idi/awardkinds";
    }
}
