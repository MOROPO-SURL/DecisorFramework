using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Commercial.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Commercial.Presentation.Web.Frontend.Controllers.API
{
    [Route("api/commercial/[controller]")]
    [ApiController]
    public class LegalProvidersController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<LegalProvider, System.Guid, LegalProviderInputModel, LegalProviderDisplayModel>
    {
        public LegalProvidersController(IEntityRepository<LegalProvider, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<LegalProvidersController> localizer, Microsoft.Extensions.Logging.ILogger<LegalProvidersController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<LegalProvider, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.Enabled;
        }

        public override ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override LegalProviderDisplayModel EntityToDisplayModel(LegalProvider entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (model.Contact.Identity.Image != null)
            {
                model.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Contact.Identity.Image.ContentType);
            }

            return model;
        }
    }
}
