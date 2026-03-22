namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Connect.Clients
{
    public class ProjectCategoriesAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEnableableEntityConsultAPIConnectClient<Persistence.Entities.ProjectCategory, System.Guid, Common.Models.Display.ProjectCategoryDisplayModel>
    {
        public ProjectCategoriesAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/idi/projectcategories";
    }
}