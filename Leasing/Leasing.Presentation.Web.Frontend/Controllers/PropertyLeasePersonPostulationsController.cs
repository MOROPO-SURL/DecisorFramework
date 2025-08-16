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
    public class PropertyLeasePersonPostulationsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIManagementController<PropertyLeasePersonPostulation, System.Guid, PropertyLeasePersonPostulationInputModel, PropertyLeasePersonPostulationDisplayModel>
    {
        public PropertyLeasePersonPostulationsController(IEntityRepository<PropertyLeasePersonPostulation, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<PropertyLeasePersonPostulationsController> localizer, ILogger<PropertyLeasePersonPostulationsController> logger) : base(repository, localizer, logger)
        {
        }
    }
}