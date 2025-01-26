namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Connect.Clients
{
    public class EmployeesAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.Employee, System.Guid, Common.Models.Input.EmployeeInputModel, Common.Models.Display.EmployeeDisplayModel>
    {
        public EmployeesAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/hhrr/employees";
    }
}
