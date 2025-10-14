namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Connect.Clients
{
    public class StaffsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.Staff, System.Guid, Common.Models.Input.StaffInputModel, Common.Models.Display.StaffDisplayModel>
    {
        public StaffsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/hhrr/staffs";
    }
}
