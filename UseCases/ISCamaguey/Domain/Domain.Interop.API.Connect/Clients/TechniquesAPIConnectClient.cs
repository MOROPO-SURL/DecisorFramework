namespace MOROPO.ISCamaguey.Decisor.Domain.Interop.API.Connect.Clients
{
    public class TechniquesAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.Technique, System.Guid, Common.Models.Input.TechniqueInputModel, Common.Models.Display.TechniqueDisplayModel, Common.Models.Filter.TechniqueFilterModel>
    {
        public TechniquesAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/domain/techniques";
    }
}
