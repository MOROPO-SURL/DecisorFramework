using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Extensions;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/fwrk/domain/[controller]")]
    [ApiController]
    public class BrandsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<Brand, System.Guid, BrandInputModel, BrandDisplayModel, BrandFilterModel>
    {
        private readonly IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository;

        public BrandsController(IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository, IEntityRepository<Brand, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<BrandsController> localizer, Microsoft.Extensions.Logging.ILogger<BrandsController> logger) : base(repository, localizer, logger)
        {
            this.changeNotificationRepository = changeNotificationRepository;
        }

        protected override System.Func<Brand, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override void PostCreate(Brand entity, BrandInputModel model)
        {
            base.PostCreate(entity, model);

            this.ChangeNotificationOnPostCreate(entity, model, changeNotificationRepository);
        }

        protected override void PostEdit(Brand entity, BrandInputModel model)
        {
            base.PostEdit(entity, model);

            this.ChangeNotificationOnPostEdit(entity, model, changeNotificationRepository);
        }
    }
}