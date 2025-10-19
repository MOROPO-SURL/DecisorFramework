namespace MOROPO.ISCamaguey.Decisor.Domain.Interop.API.Connect.Clients
{
    public class SampleKindsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityConsultFilteredAPIConnectClient<Persistence.Entities.SampleKind, System.Guid, Common.Models.Display.SampleKindDisplayModel, Common.Models.Filter.SampleKindFilterModel>
    {
        public SampleKindsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/domain/samplekinds";
    }
}