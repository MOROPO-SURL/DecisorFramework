using Microsoft.EntityFrameworkCore;
using MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities;
using System.Linq;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Persistence.ORM.EF.Repositories;

public class ObjectiveUserBridgeRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractBridgeRepository<ObjectiveUserBridge, Objective, System.Guid, Framework.Guama.Security.Personal.Persistence.Entities.User, string>
{
    public ObjectiveUserBridgeRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<ObjectiveUserBridge> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet().Include(bridge => bridge.Stern).ThenInclude(entity => entity.Identity);
    }
}
