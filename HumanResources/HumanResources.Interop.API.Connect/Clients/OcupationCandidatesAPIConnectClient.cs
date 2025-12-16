namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Connect.Clients
{
    public class OcupationCandidatesAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.OcupationCandidate, System.Guid, Common.Models.Input.OcupationCandidateInputModel, Common.Models.Display.OcupationCandidateDisplayModel, Common.Models.Filter.OcupationCandidateFilterModel>
    {
        public OcupationCandidatesAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/hhrr/ocupationcandidates";
    }
}
