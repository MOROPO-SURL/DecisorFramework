namespace MOROPO.Framework.Decisor.Core.Interop.API.Connect.Clients
{
    public class MunicipalitiesAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityConsultFilteredAPIConnectClient<Guama.Location.Persistence.Entities.Municipality, System.Guid, Common.Models.Display.MunicipalityDisplayModel, Common.Models.Filter.MunicipalityFilterModel>
    {
        public MunicipalitiesAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/municipalities";
    }
}
