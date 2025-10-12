namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Connect.Clients
{
    public class EmployeeDailyCheckingsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityManagementFilteredAPIConnectClient<Persistence.Entities.EmployeeDailyChecking, long, Common.Models.Input.EmployeeDailyCheckingInputModel, Common.Models.Display.EmployeeDailyCheckingDisplayModel, Common.Models.Filter.EmployeeDailyCheckingFilterModel>
    {
        public EmployeeDailyCheckingsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/hhrr/employeedailycheckings";
    }
}
