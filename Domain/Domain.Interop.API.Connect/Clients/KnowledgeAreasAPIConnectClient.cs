
namespace MOROPO.Framework.Decisor.Domain.Interop.API.Connect.Clients
{
    public class KnowledgeAreasAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.KnowledgeArea, System.Guid, Common.Models.Input.KnowledgeAreaInputModel, Common.Models.Display.KnowledgeAreaDisplayModel, Common.Models.Filter.KnowledgeAreaFilterModel>
    {
        public KnowledgeAreasAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/domain/knowledgeareas";
    }
}
