namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Connect.Clients
{
    public class NamingEmploymentContractsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityConsultFilteredAPIConnectClient<Persistence.Entities.NamingEmploymentContract, int, Common.Models.Display.NamingEmploymentContractDisplayModel, Common.Models.Filter.NamingEmploymentContractFilterModel>
    {
        public NamingEmploymentContractsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/hhrr/namingemploymentcontracts";
    }
}
