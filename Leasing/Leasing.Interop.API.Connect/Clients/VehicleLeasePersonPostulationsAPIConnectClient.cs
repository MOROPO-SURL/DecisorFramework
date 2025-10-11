using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Connect.Clients
{
    public class VehicleLeasePersonPostulationsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityManagementAPIConnectClient<VehicleLeasePersonPostulation, System.Guid, VehicleLeasePersonPostulationInputModel, VehicleLeasePersonPostulationDisplayModel>
    {
        public VehicleLeasePersonPostulationsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/leasing/vehicleleasepersonpostulations";
    }
}
