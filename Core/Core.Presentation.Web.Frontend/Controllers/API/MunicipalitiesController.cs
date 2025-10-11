namespace MOROPO.Framework.Decisor.Core.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/fwrk/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class MunicipalitiesController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIConsultFilteredController<Guama.Location.Persistence.Entities.Municipality, System.Guid, Interop.API.Common.Models.Display.MunicipalityDisplayModel, Interop.API.Common.Models.Filter.MunicipalityFilterModel>
    {
        public MunicipalitiesController(Guama.Core.Persistence.Repositories.IEntityRepository<Guama.Location.Persistence.Entities.Municipality, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<MunicipalitiesController> localizer, Microsoft.Extensions.Logging.ILogger<MunicipalitiesController> logger) : base(repository, localizer, logger)
        {
        }
    }
}
