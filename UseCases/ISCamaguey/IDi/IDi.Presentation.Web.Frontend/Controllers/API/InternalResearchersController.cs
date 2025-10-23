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
    public class InternalResearchersController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<InternalResearcher, System.Guid, InternalResearcherInputModel, InternalResearcherDisplayModel, InternalResearcherFilterModel>
    {
        public InternalResearchersController(IEntityRepository<InternalResearcher, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<InternalResearchersController> localizer, Microsoft.Extensions.Logging.ILogger<InternalResearchersController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<InternalResearcher, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<InternalResearcher, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        protected override InternalResearcherDisplayModel EntityToDisplayModel(InternalResearcher entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (entity.Employee.Contact.Identity.Image != null)
            {
                model.Employee.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Employee.Contact.Identity.Image.ContentType);
            }

            return model;
        }
    }
}
