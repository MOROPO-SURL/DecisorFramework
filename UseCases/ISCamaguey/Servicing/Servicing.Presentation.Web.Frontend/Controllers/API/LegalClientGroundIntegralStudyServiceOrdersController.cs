
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
    public class LegalClientGroundIntegralStudyServiceOrdersController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<LegalClientGroundIntegralStudyServiceOrder, long, LegalClientGroundIntegralStudyServiceOrderInputModel, LegalClientGroundIntegralStudyServiceOrderDisplayModel, LegalClientGroundIntegralStudyServiceOrderFilterModel>
    {
        public LegalClientGroundIntegralStudyServiceOrdersController(IEntityRepository<LegalClientGroundIntegralStudyServiceOrder, long> repository, Microsoft.Extensions.Localization.IStringLocalizer<LegalClientGroundIntegralStudyServiceOrdersController> localizer, Microsoft.Extensions.Logging.ILogger<LegalClientGroundIntegralStudyServiceOrdersController> logger) : base(repository, localizer, logger)
        {
        }
        protected override System.Linq.Expressions.Expression<System.Func<LegalClientGroundIntegralStudyServiceOrder, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<LegalClientGroundIntegralStudyServiceOrder, object> GetOrderSelector()
        {
            return entity => entity.At;
        }

        protected override bool IsOrderDescending()
        {
            return true;
        }

        protected override LegalClientGroundIntegralStudyServiceOrderDisplayModel EntityToDisplayModel(LegalClientGroundIntegralStudyServiceOrder entity)
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
