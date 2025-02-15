namespace MOROPO.Framework.Decisor.Core.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class StatesController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIConsultController<Guama.Location.Persistence.Entities.State, System.Guid, Interop.API.Common.Models.Display.StateDisplayModel>
    {
        public StatesController(Guama.Core.Persistence.Repositories.IEntityRepository<Guama.Location.Persistence.Entities.State, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<StatesController> localizer, Microsoft.Extensions.Logging.ILogger<StatesController> logger) : base(repository, localizer, logger)
        {
        }
    }
}
