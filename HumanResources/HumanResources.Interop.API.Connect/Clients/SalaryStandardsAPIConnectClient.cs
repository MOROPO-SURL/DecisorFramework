namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Connect.Clients
{
    public class SalaryStandardsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.SalaryStandard, System.Guid, Common.Models.Input.SalaryStandardInputModel, Common.Models.Display.SalaryStandardDisplayModel>
    {
        public SalaryStandardsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/hhrr/salarystandards";
    }
}
