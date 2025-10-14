namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Connect.Clients
{
    public class VacantPostulationsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.VacantPostulation, System.Guid, Common.Models.Input.VacantPostulationInputModel, Common.Models.Display.VacantPostulationDisplayModel>
    {
        public VacantPostulationsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/hhrr/vacantpostulations";
    }
}