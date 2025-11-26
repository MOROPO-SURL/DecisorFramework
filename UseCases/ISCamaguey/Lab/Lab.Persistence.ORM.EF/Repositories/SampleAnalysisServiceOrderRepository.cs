using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.ORM.EF.Repositories
{
    public class SampleAnalysisServiceOrderRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Servicing.Persistence.Entities.Contract.AbstractSampleAnalysisServiceOrder, long>
    {
        public SampleAnalysisServiceOrderRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Servicing.Persistence.Entities.Contract.AbstractSampleAnalysisServiceOrder> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Service)
                .Include(entity => entity.RequestedTechnique);
        }
    }
}
