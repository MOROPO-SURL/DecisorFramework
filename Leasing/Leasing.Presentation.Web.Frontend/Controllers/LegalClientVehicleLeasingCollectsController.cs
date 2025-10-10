using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Web.Frontend.Controllers
{
    [Route("api/leasing/[controller]")]
    [ApiController]
    public class LegalClientVehicleLeasingCollectsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<LegalClientVehicleLeasingCollect, System.Guid, LegalClientVehicleLeasingCollectInputModel, LegalClientVehicleLeasingCollectDisplayModel, LegalClientVehicleLeasingCollectFilterModel>
    {
        public LegalClientVehicleLeasingCollectsController(IEntityRepository<LegalClientVehicleLeasingCollect, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<LegalClientVehicleLeasingCollectsController> localizer, ILogger<LegalClientVehicleLeasingCollectsController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<LegalClientVehicleLeasingCollect, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        public override ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override System.Func<LegalClientVehicleLeasingCollect, object> GetOrderSelector()
        {
            return entity => entity.At;
        }

        protected override bool IsOrderDescending()
        {
            return true;
        }

        protected override LegalClientVehicleLeasingCollectDisplayModel EntityToDisplayModel(LegalClientVehicleLeasingCollect entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (entity.Leasing.Contract.Client.Contact.Identity.Image != null)
            {
                model.Leasing.Contract.Client.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Leasing.Contract.Client.Contact.Identity.Image.ContentType);
            }

            if (entity.Leasing.Contract.Postulation.Offer.Propousal.Vehicle.FeatureImage != null)
            {
                model.Leasing.Contract.Vehicle.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Leasing.Contract.Postulation.Offer.Propousal.Vehicle.FeatureImage.ContentType);
            }

            return model;
        }
    }
}
