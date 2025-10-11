using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Connect.Clients
{
    public class PropertyLeaseOrganizationPostulationsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityManagementAPIConnectClient<PropertyLeaseOrganizationPostulation, System.Guid, PropertyLeaseOrganizationPostulationInputModel, PropertyLeaseOrganizationPostulationDisplayModel>
    {
        public PropertyLeaseOrganizationPostulationsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/leasing/propertyleaseorganizationpostulations";
    }
}
