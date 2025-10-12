using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Domain.Interop.API.Connect.Clients
{
    public class OrganizationContactsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<OrganizationContact, System.Guid, OrganizationContactInputModel, OrganizationContactDisplayModel>
    {
        public OrganizationContactsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/domain/organizationcontacts";
    }
}
