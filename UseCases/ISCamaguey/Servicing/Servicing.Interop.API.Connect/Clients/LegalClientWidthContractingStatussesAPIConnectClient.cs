namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Connect.Clients
{
    public class LegalClientWidthContractingStatussesAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityConsultFilteredAPIConnectClient<Framework.Decisor.Commercial.Persistence.Entities.LegalClient, System.Guid, Common.Models.Display.LegalClientWidthContractStatusDisplayModel, Framework.Decisor.Commercial.Interop.API.Common.Models.Filter.LegalClientFilterModel>
    {
        public LegalClientWidthContractingStatussesAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/servicing/legalclientwidthcontractingstatusses";
    }
}
