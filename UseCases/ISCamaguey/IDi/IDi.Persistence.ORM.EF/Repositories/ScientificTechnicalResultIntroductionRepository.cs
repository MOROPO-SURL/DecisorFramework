using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Repositories;

public sealed class ScientificTechnicalResultIntroductionRepository : AbstractEntityRepository<ScientificTechnicalResultIntroduction, System.Guid>
{
    public ScientificTechnicalResultIntroductionRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<ScientificTechnicalResultIntroduction> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .Include(entity => entity.Result)
            .Include(entity => entity.EmployeeBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image);
    }
}