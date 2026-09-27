namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Connect.Clients
{
    public class PublicationResultsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.PublicationResult, System.Guid, Common.Models.Input.PublicationResultInputModel, Common.Models.Display.PublicationResultDisplayModel, Common.Models.Filter.PublicationResultFilterModel>
    {
        public PublicationResultsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/idi/publicationresults";
    }
}