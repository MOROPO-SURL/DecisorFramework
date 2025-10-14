namespace MOROPO.Framework.Decisor.Essential.Interop.API.Connect.Clients
{
    public class ColaboratorsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.Colaborator, System.Guid, Common.Models.Input.ColaboratorInputModel, Common.Models.Display.ColaboratorDisplayModel>
    {
        public ColaboratorsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/essential/colaborators";
    }
}
