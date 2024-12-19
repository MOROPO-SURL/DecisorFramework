using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Commercial.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Commercial.Presentation.Web.Frontend.Controllers.API
{
    [Route("api/commercial/[controller]")]
    [ApiController]
    public class NaturalProvidersController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<NaturalProvider, System.Guid, NaturalProviderInputModel, NaturalProviderDisplayModel>
    {
        public NaturalProvidersController(IEntityRepository<NaturalProvider, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<NaturalProvidersController> localizer, Microsoft.Extensions.Logging.ILogger<NaturalProvidersController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<NaturalProvider, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.Enabled;
        }

        public override ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override NaturalProviderDisplayModel EntityToDisplayModel(NaturalProvider entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (model.Contact.Identity.Image != null)
            {
                model.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Contact.Identity.Image.ContentType);
            }

            return model;
        }

        [HttpGet("[action]")]
        public ActionResult<long> Count()
        {
            return Ok(Repository.Count());
        }
    }
}
