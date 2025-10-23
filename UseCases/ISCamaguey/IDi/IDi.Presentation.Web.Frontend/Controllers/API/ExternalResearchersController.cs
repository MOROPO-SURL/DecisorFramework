using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Filter;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Frontend.Controllers.API
{
    [Route("api/idi/[controller]")]
    [ApiController]
    public class ExternalResearchersController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<ExternalResearcher, System.Guid, ExternalResearcherInputModel, ExternalResearcherDisplayModel, ExternalResearcherFilterModel>
    {
        public ExternalResearchersController(IEntityRepository<ExternalResearcher, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ExternalResearchersController> localizer, Microsoft.Extensions.Logging.ILogger<ExternalResearchersController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<ExternalResearcher, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<ExternalResearcher, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        protected override ExternalResearcherDisplayModel EntityToDisplayModel(ExternalResearcher entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (entity.Contact.Identity.Image != null)
            {
                model.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Contact.Identity.Image.ContentType);
            }

            if (entity.ParticipatingOrganization.Contact.Identity.Image != null)
            {
                model.ParticipatingOrganization.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.ParticipatingOrganization.Contact.Identity.Image.ContentType);
            }

            return model;
        }
    }
}
