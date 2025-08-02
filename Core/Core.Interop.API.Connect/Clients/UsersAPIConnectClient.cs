namespace MOROPO.Framework.Decisor.Core.Interop.API.Connect.Clients
{
    public class UsersAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityConsultAPIConnectClient<Guama.Security.Personal.Persistence.Entities.User, string, Common.Models.Display.UserDisplayModel>
    {
        public UsersAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/users";
    }
}
