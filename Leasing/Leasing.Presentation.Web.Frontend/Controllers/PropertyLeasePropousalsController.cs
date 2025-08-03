using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Web.Frontend.Controllers
{
    [Route("api/leasing/[controller]")]
    [ApiController]
    public class PropertyLeasePropousalsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementController<PropertyLeasePropousal, System.Guid, PropertyLeasePropousalInputModel, PropertyLeasePropousalDisplayModel>
    {
        public PropertyLeasePropousalsController(IEntityRepository<PropertyLeasePropousal, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<PropertyLeasePropousalsController> localizer, ILogger<PropertyLeasePropousalsController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<PropertyLeasePropousal, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<PropertyLeasePropousal, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        protected override PropertyLeasePropousalDisplayModel EntityToDisplayModel(PropertyLeasePropousal entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (model.Author.Contact.Identity.Image != null)
            {
                model.Author.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Author.Contact.Identity.Image.ContentType);
            }

            if (model.Property.FeatureImage != null)
            {
                model.Property.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Property.FeatureImage.ContentType);
            }

            return model;
        }
    }
}
