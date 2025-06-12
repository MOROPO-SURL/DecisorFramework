namespace MOROPO.Framework.Decisor.Core.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class UsersController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIConsultController<Guama.Security.Personal.Persistence.Entities.User, string, Interop.API.Common.Models.Display.UserDisplayModel>
    {
        public UsersController(Guama.Core.Persistence.Repositories.IEntityRepository<Guama.Security.Personal.Persistence.Entities.User, string> repository, Microsoft.Extensions.Localization.IStringLocalizer<UsersController> localizer, Microsoft.Extensions.Logging.ILogger<UsersController> logger) : base(repository, localizer, logger)
        {
        }
    }
}