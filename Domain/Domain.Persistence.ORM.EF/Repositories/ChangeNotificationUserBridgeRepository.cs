using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Repositories;

public class ChangeNotificationUserBridgeRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractBridgeRepository<Entities.ChangeNotificationUserBridge, Entities.ChangeNotification, System.Guid, Guama.Security.Personal.Persistence.Entities.User, string>
{
    public ChangeNotificationUserBridgeRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override System.Linq.IQueryable<Entities.ChangeNotificationUserBridge> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .Include(bridge => bridge.Stern).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
            .Include(bridge => bridge.Prow).ThenInclude(entity => entity.Author).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image);
    }
}
