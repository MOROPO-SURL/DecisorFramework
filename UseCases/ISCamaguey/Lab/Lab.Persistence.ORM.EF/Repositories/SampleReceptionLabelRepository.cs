using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.ORM.EF.Repositories
{
    public class SampleReceptionLabelRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.SampleReceptionLabel, System.Guid>
    {
        public SampleReceptionLabelRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.SampleReceptionLabel> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(entity => entity.Sample);
        }
    }
}