namespace MOROPO.Framework.Decisor.Governance.Interop.API.Connect.Clients
{
    public class AgreementsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityConsultAPIConnectClient<Persistence.Entities.Agreement, System.Guid, Common.Models.Display.AgreementDisplayModel>
    {
        public AgreementsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/governance/agreements";
    }
}
