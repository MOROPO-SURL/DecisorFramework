
using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Filter;
using MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Web.Frontend.Controllers.API
{
    [Route("api/servicing/[controller]")]
    [ApiController]
    public class LegalClientTrainingServiceOrdersController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<LegalClientTrainingServiceOrder, long, LegalClientTrainingServiceOrderInputModel, LegalClientTrainingServiceOrderDisplayModel, LegalClientTrainingServiceOrderFilterModel>
    {
        public LegalClientTrainingServiceOrdersController(IEntityRepository<LegalClientTrainingServiceOrder, long> repository, Microsoft.Extensions.Localization.IStringLocalizer<LegalClientTrainingServiceOrdersController> localizer, Microsoft.Extensions.Logging.ILogger<LegalClientTrainingServiceOrdersController> logger) : base(repository, localizer, logger)
        {
        }
        protected override System.Linq.Expressions.Expression<System.Func<LegalClientTrainingServiceOrder, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<LegalClientTrainingServiceOrder, object> GetOrderSelector()
        {
            return entity => entity.At;
        }

        protected override bool IsOrderDescending()
        {
            return true;
        }

        protected override LegalClientTrainingServiceOrderDisplayModel EntityToDisplayModel(LegalClientTrainingServiceOrder entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (entity.Contract.Client.Contact.Identity.Image != null)
            {
                model.Contract.Client.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Contract.Client.Contact.Identity.Image.ContentType);
            }

            return model;
        }

        public override ActionResult Delete(long key)
        {
            return NotFound();
        }
    }
}
