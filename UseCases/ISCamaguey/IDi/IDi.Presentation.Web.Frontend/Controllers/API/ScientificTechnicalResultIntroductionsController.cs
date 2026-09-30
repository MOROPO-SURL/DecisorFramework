using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Filter;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Frontend.Controllers.API;

[Route("api/idi/[controller]")]
[ApiController]
public sealed class ScientificTechnicalResultIntroductionsController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<ScientificTechnicalResultIntroduction, System.Guid, ScientificTechnicalResultIntroductionInputModel, ScientificTechnicalResultIntroductionDisplayModel, ScientificTechnicalResultIntroductionFilterModel>
{
    public ScientificTechnicalResultIntroductionsController(IEntityRepository<ScientificTechnicalResultIntroduction, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ScientificTechnicalResultIntroductionsController> localizer, Microsoft.Extensions.Logging.ILogger<ScientificTechnicalResultIntroductionsController> logger)
        : base(repository, localizer, logger)
    {
    }

    protected override System.Linq.Expressions.Expression<System.Func<ScientificTechnicalResultIntroduction, bool>> GetGlobalSelector() => entity => !entity.Archived;

    protected override System.Func<ScientificTechnicalResultIntroduction, object> GetOrderSelector() => entity => entity.At;

    protected override bool IsOrderDescending() => true;

    public override ActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    protected override ScientificTechnicalResultIntroductionDisplayModel EntityToDisplayModel(ScientificTechnicalResultIntroduction entity)
    {
        var model = base.EntityToDisplayModel(entity);

        model.Supervisors = [.. entity.EmployeeBridges.Select(bridge =>
        {
            EmployeeDisplayModel _model = new();

            _model.Import(bridge.Stern);

            if (_model.Contact.Identity.Image != null)
            {
                _model.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.Contact.Identity.Image.ContentType);
            }

            return _model;
        })];

        return model;
    }
}