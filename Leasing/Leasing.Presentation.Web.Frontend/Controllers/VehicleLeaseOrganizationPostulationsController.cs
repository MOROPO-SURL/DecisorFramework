using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Web.Frontend.Controllers
{
    [Route("api/leasing/[controller]")]
    [ApiController]
    public class VehicleLeaseOrganizationPostulationsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIManagementController<VehicleLeaseOrganizationPostulation, System.Guid, VehicleLeaseOrganizationPostulationInputModel, VehicleLeaseOrganizationPostulationDisplayModel>
    {
        public VehicleLeaseOrganizationPostulationsController(IEntityRepository<VehicleLeaseOrganizationPostulation, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<VehicleLeaseOrganizationPostulationsController> localizer, ILogger<VehicleLeaseOrganizationPostulationsController> logger) : base(repository, localizer, logger)
        {
        }
    }
}