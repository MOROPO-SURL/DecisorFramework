using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Controllers.API
{
    [Route("api/domain/[controller]")]
    [ApiController]
    public class BrandsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIManagementController<Brand, System.Guid, BrandInputModel, BrandDisplayModel>
    {
        public BrandsController(Guama.Core.Persistence.Repositories.IEntityRepository<Brand, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<BrandsController> localizer, Microsoft.Extensions.Logging.ILogger<BrandsController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Func<Brand, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }
    }
}
