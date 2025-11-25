namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Connect.Clients
{
    public class NaturalClientWidthContractingStatussesAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityConsultFilteredAPIConnectClient<Framework.Decisor.Commercial.Persistence.Entities.NaturalClient, System.Guid, Common.Models.Display.NaturalClientWidthContractStatusDisplayModel, Framework.Decisor.Commercial.Interop.API.Common.Models.Filter.NaturalClientFilterModel>
    {
        public NaturalClientWidthContractingStatussesAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/servicing/naturalclientwidthcontractingstatusses";
    }
}
