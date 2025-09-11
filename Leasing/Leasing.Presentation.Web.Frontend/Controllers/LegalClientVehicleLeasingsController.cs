using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Web.Frontend.Controllers
{
    [Route("api/leasing/[controller]")]
    [ApiController]
    public class LegalClientVehicleLeasingsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<LegalClientVehicleLeasing, System.Guid, LegalClientVehicleLeasingInputModel, LegalClientVehicleLeasingDisplayModel>
    {
        public LegalClientVehicleLeasingsController(Guama.Core.Persistence.Repositories.IEntityRepository<LegalClientVehicleLeasing, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<LegalClientVehicleLeasingsController> localizer, Microsoft.Extensions.Logging.ILogger<LegalClientVehicleLeasingsController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<LegalClientVehicleLeasing, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<LegalClientVehicleLeasing, object> GetOrderSelector()
        {
            return entity => entity.Contract.At;
        }

        protected override bool IsOrderDescending()
        {
            return true;
        }

        public override ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override LegalClientVehicleLeasingDisplayModel EntityToDisplayModel(LegalClientVehicleLeasing entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (entity.Contract.Client.Contact.Identity.Image != null)
            {
                model.Contract.Client.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Contract.Client.Contact.Identity.Image.ContentType);
            }

            if (entity.Contract.Postulation.Offer.Propousal.Vehicle.FeatureImage != null)
            {
                model.Contract.Vehicle.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Contract.Client.Contact.Identity.Image.ContentType);
            }

            var members = new System.Collections.Generic.List<Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel>();

            foreach (var bridge in entity.ContactBridges)
            {
                var _model = new Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel();

                _model.Import(bridge.Stern);

                if (bridge.Stern.Identity.Image != null)
                    _model.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.Identity.Image.ContentType);

                members.Add(_model);
            }

            model.Drivers = members.ToArray();

            return model;
        }
    }
}
