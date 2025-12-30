using Microsoft.EntityFrameworkCore;
using MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities;
using System.Linq;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Persistence.ORM.EF.Repositories;

public class UnitMeasurementRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Prototype.Persistence.Entities.UnitMeasurement, System.Guid>
{
    public UnitMeasurementRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<UnitMeasurement> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet().AsNoTracking();
    }
}