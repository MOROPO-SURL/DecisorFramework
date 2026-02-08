using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using System.Linq;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Controllers.API;

[Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
[Route("api/fwrk/domain/notifications/changes")]
[ApiController]
public class ChangeNotificationsController : Guama.Core.Presentation.Web.Common.Controllers.BaseWebController
{
    private readonly IBridgeRepository<ChangeNotificationUserBridge, ChangeNotification, System.Guid, Guama.Security.Personal.Persistence.Entities.User, string> repository;
    private readonly DbContext dbContext;

    public ChangeNotificationsController(DbContext dbContext, IBridgeRepository<ChangeNotificationUserBridge, ChangeNotification, System.Guid, Guama.Security.Personal.Persistence.Entities.User, string> repository, Microsoft.Extensions.Localization.IStringLocalizer<ChangeNotificationsController> localizer, Microsoft.Extensions.Logging.ILogger<ChangeNotificationsController> logger) : base(localizer, logger)
    {
        this.repository = repository;
        this.dbContext = dbContext;
    }

    [HttpGet]
    [Route("unread/count")]
    public ActionResult<long> CountUnread()
    {
        return repository.Count(bridge => bridge.SternId == User.Identity.Name && bridge.ReadedAt == null);
    }

    [HttpGet]
    [Route("page/{sheet}")]
    [Route("page/{sheet}/limit/{limit}")]
    public ActionResult<Guama.Core.Presentation.Models.PaginationModel<Interop.API.Common.Models.Display.ChangeNotificationDisplayModel>> GetPaginate(int sheet = 1, int limit = 25)
    {
        var selection = repository.FindBy(bridge => bridge.SternId == User.Identity.Name);

        var maxCount = selection.Count();

        var model = new Guama.Core.Presentation.Models.PaginationModel<Interop.API.Common.Models.Display.ChangeNotificationDisplayModel>
        {
            Limit = limit,
            Page = 0,
            HasNext = false,
            HasPrevious = false,
            List = []
        };

        if (maxCount > 0)
        {
            var rest = maxCount % limit;

            var maxPageCount = maxCount / limit;
            
            if (rest > 0) maxPageCount += 1;

            if (sheet < 0 || sheet > maxPageCount)
            {
                sheet = 1;
            }

            var models = selection.Skip((sheet - 1) * limit).Take(limit).OrderByDescending(bridge => bridge.At).ToList().Select(bridge =>
            {
                var _model = new Interop.API.Common.Models.Display.ChangeNotificationDisplayModel(bridge.At);

                _model.Import(bridge.Prow);

                _model.ReadedAt = bridge.ReadedAt;

                return _model;
            }).ToList();

            model = new Guama.Core.Presentation.Models.PaginationModel<Interop.API.Common.Models.Display.ChangeNotificationDisplayModel>
            {
                Limit = limit,
                Page = sheet,
                HasPrevious = sheet > 1,
                HasNext = sheet < maxPageCount,
                MaxPageCount = maxPageCount,
                List = models
            };
        }

        return Ok(model);
    }

    [HttpPut]
    [Route("readed/{id}")]
    public ActionResult MarkAsReaded(System.Guid id)
    {
        var bridge = repository.FindOneBy(_bridge => _bridge.ProwId == id && _bridge.SternId == User.Identity.Name);

        bridge.ReadedAt = System.DateTime.Now;

        var entry = dbContext.Entry(bridge);

        entry.State = EntityState.Modified;

        (dbContext as Guama.Core.Persistence.ORM.EF.Context.Contract.ITraceableDbContext).SaveChanges(User.Identity.Name, true);

        return Ok();
    }

    [HttpPut]
    [Route("readed/all")]
    public ActionResult MarkAllAsReaded()
    {
        var bridges = repository.FindBy(bridge => bridge.SternId == User.Identity.Name && bridge.ReadedAt == null).ToArray();

        foreach (var bridge in bridges)
        {
            bridge.ReadedAt = System.DateTime.Now;

            var entry = dbContext.Entry(bridge);

            entry.State = EntityState.Modified;
        }

        (dbContext as Guama.Core.Persistence.ORM.EF.Context.Contract.ITraceableDbContext).SaveChanges(User.Identity.Name, true);

        return Ok();
    }
}