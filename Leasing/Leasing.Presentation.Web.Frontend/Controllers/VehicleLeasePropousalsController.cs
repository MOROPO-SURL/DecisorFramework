using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Web.Frontend.Controllers
{
    [Route("api/fwrk/leasing/[controller]")]
    [ApiController]
    public class VehicleLeasePropousalsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementController<VehicleLeasePropousal, System.Guid, VehicleLeasePropousalInputModel, VehicleLeasePropousalDisplayModel>
    {
        public VehicleLeasePropousalsController(IEntityRepository<VehicleLeasePropousal, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<VehicleLeasePropousalsController> localizer, ILogger<VehicleLeasePropousalsController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<VehicleLeasePropousal, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<VehicleLeasePropousal, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        protected override VehicleLeasePropousalDisplayModel EntityToDisplayModel(VehicleLeasePropousal entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (model.Author.Contact.Identity.Image != null)
            {
                model.Author.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Author.Contact.Identity.Image.ContentType);
            }

            if (model.Vehicle.FeatureImage != null)
            {
                model.Vehicle.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Vehicle.FeatureImage.ContentType);
            }

            return model;
        }
    }
}
