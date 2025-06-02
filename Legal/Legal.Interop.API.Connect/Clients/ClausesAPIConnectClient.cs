namespace MOROPO.Framework.Decisor.Legal.Interop.API.Connect.Clients
{
    public class ClausesAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.Clause, System.Guid, Common.Models.Input.ClauseInputModel, Common.Models.Display.ClauseDisplayModel>
    {
        public ClausesAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/legal/clauses";
    }
}