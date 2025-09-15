using Microsoft.EntityFrameworkCore;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Persistence.ORM.EF.Repositories
{
    public class ResultRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Prototype.Persistence.Entities.Result, long>
    {
        public ResultRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Prototype.Persistence.Entities.Result> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Indicator).ThenInclude(entity => entity.UnitMeasurement)
                .Include(entity => entity.Indicator).ThenInclude(entity => entity.Action).ThenInclude(entity => entity.Proyection).ThenInclude(entity => entity.Objective);
        }
    }
}
