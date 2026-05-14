namespace MOROPO.Framework.Decisor.Financial.Interop.API.Connect.Clients
{
    public class BankBranchesAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.BankBranch, System.Guid, Common.Models.Input.BankBranchInputModel, Common.Models.Display.BankBranchDisplayModel, Common.Models.Filter.BankBranchFilterModel>
    {
        public BankBranchesAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/financial/bankbranches";
    }
}
