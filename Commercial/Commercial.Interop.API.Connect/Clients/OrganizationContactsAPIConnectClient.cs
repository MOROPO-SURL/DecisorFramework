using MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Input;

namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Connect.Clients
{
    public class OrganizationContactsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.OrganizationContact, System.Guid, OrganizationContactInputModel, OrganizationContactDisplayModel>
    {
        public OrganizationContactsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/commercial/organizationcontacts";

        public async System.Threading.Tasks.Task<long> CountAsync()
        {
            return await httpClientHelperProvider.HttpClientHelper.GetAsync<long>($"{TargetController}/count");
        }
    }
}
