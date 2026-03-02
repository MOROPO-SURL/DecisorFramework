namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Connect.Clients
{
    public class DesignationEmploymentContractsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityConsultFilteredAPIConnectClient<Persistence.Entities.DesignationEmploymentContract, System.Guid, Common.Models.Display.DesignationEmploymentContractDisplayModel, Common.Models.Filter.DesignationEmploymentContractFilterModel>
    {
        public DesignationEmploymentContractsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/hhrr/designationemploymentcontracts";
    }
}