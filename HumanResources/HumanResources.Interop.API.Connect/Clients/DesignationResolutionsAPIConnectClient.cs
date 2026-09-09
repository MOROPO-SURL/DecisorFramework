namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Connect.Clients
{
    public class DesignationResolutionsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.DesignationResolution, System.Guid, Common.Models.Input.DesignationResolutionInputModel, Common.Models.Display.DesignationResolutionDisplayModel, Common.Models.Filter.DesignationResolutionFilterModel>
    {
        public DesignationResolutionsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/hhrr/designationresolutions";
    }
}