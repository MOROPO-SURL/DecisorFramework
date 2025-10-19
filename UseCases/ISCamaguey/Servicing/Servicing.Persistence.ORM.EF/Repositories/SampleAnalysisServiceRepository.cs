using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.ORM.EF.Repositories
{
    public class SampleAnalysisServiceRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.SampleAnalysisService, System.Guid>
    {
        public SampleAnalysisServiceRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.SampleAnalysisService> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.SampleKind)
                .Include(entity => entity.DocumentBridges).ThenInclude(bridge => bridge.Stern);
        }
    }
}
