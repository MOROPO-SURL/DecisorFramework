using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Presentation.Models;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display;
using MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Input;
using MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Controllers.Frontend
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/governance/[controller]")]
    [ApiController]
    public class GuidelinesController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementController<Guideline, System.Guid, Interop.API.Common.Models.Input.GuidelineInputModel, Interop.API.Common.Models.Display.GuidelineDisplayModel>
    {
        public GuidelinesController(Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Guideline, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<GuidelinesController> localizer, Microsoft.Extensions.Logging.ILogger<GuidelinesController> logger)
            : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<Guideline, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<Guideline, object> GetOrderSelector()
        {
            return entity => entity.Index;
        }

        public override ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        public override ActionResult Enable(System.Guid key)
        {
            return NotFound(key);
        }

        public override ActionResult Disable(System.Guid key)
        {
            return NotFound();
        }

        [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.GuidelineViewerPermission)]
        public override ActionResult<GuidelineDisplayModel[]> Get()
        {
            return base.Get();
        }

        [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.GuidelineViewerPermission)]
        public override ActionResult<GuidelineDisplayModel> Get(System.Guid key)
        {
            return base.Get(key);
        }

        [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.GuidelineViewerPermission)]
        public override ActionResult<PaginationModel<GuidelineDisplayModel>> GetPaginate(int sheet = 1, int limit = 25)
        {
            return base.GetPaginate(sheet, limit);
        }

        [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.GuidelineCreatorPermission)]
        public override ActionResult Create([FromBody] GuidelineInputModel model)
        {
            return base.Create(model);
        }

        [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.GuidelineEditorPermission)]
        public override ActionResult Edit([FromBody] GuidelineInputModel model)
        {
            return base.Edit(model);
        }

        [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.GuidelineRemoverPermission)]
        public override ActionResult Archive(System.Guid key)
        {
            return base.Archive(key);
        }
    }
}
