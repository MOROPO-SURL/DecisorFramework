using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models;

namespace MOROPO.Framework.Decisor.Core.Interop.API.Connect.Clients
{
	public class SecurityAPIConnectClient
	{
        private readonly Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper httpClientHelper;

        public SecurityAPIConnectClient(Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper httpClientHelper)
        {
            this.httpClientHelper = httpClientHelper;
        }

        public async System.Threading.Tasks.Task<AuthenticatedSessionModel> AuthenticateAsync(AuthenticationIntentModel modelInput)
        {
            return await httpClientHelper.PostAsync<AuthenticationIntentModel, AuthenticatedSessionModel>("api/security/authenticate", modelInput);
        }

        public async System.Threading.Tasks.Task ChangePasswordAsync(UserPasswordChangeRequestModel model)
        {
            await httpClientHelper.PostAsync("api/security/changepassword", model);
        }
    }
}

