namespace MOROPO.Framework.Decisor.Core.Interop.API.Connect.Clients
{
    public class StatesAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityConsultAPIConnectClient<Guama.Location.Persistence.Entities.State, System.Guid, Common.Models.Display.StateDisplayModel>
    {
        public StatesAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/states";
    }
}
