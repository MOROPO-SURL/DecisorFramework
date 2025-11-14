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
    public class LegalClientServicingContractsController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<LegalClientServicingContract, int, LegalClientServicingContractInputModel, LegalClientServicingContractDisplayModel, LegalClientServicingContractFilterModel>
    {
        public LegalClientServicingContractsController(IEntityRepository<LegalClientServicingContract, int> repository, Microsoft.Extensions.Localization.IStringLocalizer<LegalClientServicingContractsController> localizer, Microsoft.Extensions.Logging.ILogger<LegalClientServicingContractsController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<LegalClientServicingContract, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<LegalClientServicingContract, object> GetOrderSelector()
        {
            return entity => entity.Year * 1000 + entity.Id;
        }

        protected override bool IsOrderDescending()
        {
            return true;
        }

        protected override LegalClientServicingContractDisplayModel EntityToDisplayModel(LegalClientServicingContract entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (entity.Client.Contact.Identity.Image != null)
            {
                model.Client.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Client.Contact.Identity.Image.ContentType);
            }

            return model;
        }
    }
}
