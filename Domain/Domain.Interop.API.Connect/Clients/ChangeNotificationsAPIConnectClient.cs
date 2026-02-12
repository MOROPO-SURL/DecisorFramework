namespace MOROPO.Framework.Decisor.Domain.Interop.API.Connect.Clients
{
    public class ChangeNotificationsAPIConnectClient
    {
        private const string TARGET_CONTROLLER = "api/fwrk/domain/notifications/changes";

        private readonly Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider;

        public ChangeNotificationsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider)
        {
            this.httpClientHelperProvider = httpClientHelperProvider;
        }

        public System.Threading.Tasks.Task<long> GetUnreadCountAsync()
        {
            return httpClientHelperProvider.HttpClientHelper.GetAsync<long>($"{TARGET_CONTROLLER}/unread/count");
        }

        public System.Threading.Tasks.Task<Guama.Core.Presentation.Models.PaginationModel<Common.Models.Display.ChangeNotificationDisplayModel>> GetPaginateAsync(int page = 1, int limit = 25)
        {
            return httpClientHelperProvider.HttpClientHelper.GetAsync<Guama.Core.Presentation.Models.PaginationModel<Common.Models.Display.ChangeNotificationDisplayModel>>($"{TARGET_CONTROLLER}/page/{page}/limit/{limit}");
        }

        public System.Threading.Tasks.Task MarkAsNotReadedAsync(System.Guid id)
        {
            return httpClientHelperProvider.HttpClientHelper.PutAsync($"{TARGET_CONTROLLER}/notreaded/{id}");
        }

        public System.Threading.Tasks.Task MarkAsReadedAsync(System.Guid id)
        {
            return httpClientHelperProvider.HttpClientHelper.PutAsync($"{TARGET_CONTROLLER}/readed/{id}");
        }

        public System.Threading.Tasks.Task MarkAllAsReadedAsync()
        {
            return httpClientHelperProvider.HttpClientHelper.PutAsync($"{TARGET_CONTROLLER}/readed/all");
        }

        public System.Threading.Tasks.Task DeleteAsync(System.Guid key)
        {
            return httpClientHelperProvider.HttpClientHelper.DeleteAsync($"{TARGET_CONTROLLER}/{key}");
        }
    }
}