namespace MOROPO.Framework.Decisor.Core.Interop.API.Connect.Clients
{
    public class UsersAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityConsultFilteredAPIConnectClient<Guama.Security.Personal.Persistence.Entities.User, string, Common.Models.Display.UserDisplayModel, Common.Models.Filter.UserFilterModel>
    {
        public UsersAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/users";
    }
}
