namespace MOROPO.Framework.Decisor.Legal.Interop.API.Connect.Clients
{
    public class SectionsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityManagementAPIConnectClient<Persistence.Entities.Section, System.Guid, Common.Models.Input.SectionInputModel, Common.Models.Display.SectionDisplayModel>
    {
        public SectionsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/legal/sections";
    }
}
