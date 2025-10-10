namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Connect.Clients
{
    public class AdmitionEmploymentContractsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityConsultFilteredAPIConnectClient<Persistence.Entities.AdmitionEmploymentContract, int, Common.Models.Display.AdmitionEmploymentContractDisplayModel, Common.Models.Filter.AdmitionEmploymentContractFilterModel>
    {
        public AdmitionEmploymentContractsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/hhrr/admitionemploymentcontracts";
    }
}
