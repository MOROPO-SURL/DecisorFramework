namespace MOROPO.Framework.Decisor.Core.Presentation.Web.Frontend.Controllers.API;

[Microsoft.AspNetCore.Mvc.Route("api/fwrk/[controller]")]
[Microsoft.AspNetCore.Mvc.ApiController]
public class UsersController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIConsultFilteredController<Guama.Security.Personal.Persistence.Entities.User, string, Interop.API.Common.Models.Display.UserDisplayModel, Interop.API.Common.Models.Filter.UserFilterModel>
{
    public UsersController(Guama.Core.Persistence.Repositories.IEntityRepository<Guama.Security.Personal.Persistence.Entities.User, string> repository, Microsoft.Extensions.Localization.IStringLocalizer<UsersController> localizer, Microsoft.Extensions.Logging.ILogger<UsersController> logger) : base(repository, localizer, logger)
    {
    }
}