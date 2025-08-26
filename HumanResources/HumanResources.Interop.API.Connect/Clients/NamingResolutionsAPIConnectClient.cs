namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Connect.Clients
{
    public class NamingResolutionsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.NamingResolution, long, Common.Models.Input.NamingResolutionInputModel, Common.Models.Display.NamingResolutionDisplayModel, Common.Models.Filter.NamingResolutionFilterModel>
    {
        public NamingResolutionsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/hhrr/namingresolutions";
    }
}
