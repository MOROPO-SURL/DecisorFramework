namespace MOROPO.Framework.Decisor.Financial.Interop.API.Connect.Clients
{
    public class BankDebitCardsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.BankDebitCard, string, Common.Models.Input.BankDebitCardInputModel, Common.Models.Display.BankDebitCardDisplayModel>
    {
        public BankDebitCardsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/financial/bankdebitcards";
    }
}
