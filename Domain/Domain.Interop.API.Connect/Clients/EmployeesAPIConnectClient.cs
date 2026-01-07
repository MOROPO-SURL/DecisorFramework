namespace MOROPO.Framework.Decisor.Domain.Interop.API.Connect.Clients
{
    public class EmployeesAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.Employee, System.Guid, Common.Models.Input.EmployeeInputModel, Common.Models.Display.EmployeeDisplayModel, Common.Models.Filter.EmployeeFilterModel>
    {
        public EmployeesAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/domain/employees";

        public virtual async System.Threading.Tasks.Task<Common.Models.Display.EmployeeDisplayModel> FindByContactAsync(System.Guid key)
        {
            return await httpClientHelperProvider.HttpClientHelper.GetAsync<Common.Models.Display.EmployeeDisplayModel>($"{TargetController}/findbycontact/{key}");
        }
    }
}