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
    public class VehicleLeasePersonPostulationsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIManagementController<VehicleLeasePersonPostulation, System.Guid, VehicleLeasePersonPostulationInputModel, VehicleLeasePersonPostulationDisplayModel>
    {
        public VehicleLeasePersonPostulationsController(IEntityRepository<VehicleLeasePersonPostulation, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<VehicleLeasePersonPostulationsController> localizer, ILogger<VehicleLeasePersonPostulationsController> logger) : base(repository, localizer, logger)
        {
        }
    }
}