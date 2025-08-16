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
    public class PropertyLeaseOrganizationPostulationsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIManagementController<PropertyLeaseOrganizationPostulation, System.Guid, PropertyLeaseOrganizationPostulationInputModel, PropertyLeaseOrganizationPostulationDisplayModel>
    {
        public PropertyLeaseOrganizationPostulationsController(IEntityRepository<PropertyLeaseOrganizationPostulation, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<PropertyLeaseOrganizationPostulationsController> localizer, ILogger<PropertyLeaseOrganizationPostulationsController> logger) : base(repository, localizer, logger)
        {
        }
    }
}
