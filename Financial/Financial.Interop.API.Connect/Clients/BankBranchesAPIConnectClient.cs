namespace MOROPO.Framework.Decisor.Financial.Interop.API.Connect.Clients
{
    public class BankBranchesAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.BankBranch, System.Guid, Common.Models.Input.BankBranchInputModel, Common.Models.Display.BankBranchDisplayModel>
    {
        public BankBranchesAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/financial/bankbranches";
    }
}
