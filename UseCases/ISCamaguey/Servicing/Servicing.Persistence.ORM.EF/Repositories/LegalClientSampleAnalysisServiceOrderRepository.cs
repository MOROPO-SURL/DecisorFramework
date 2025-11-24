using Microsoft.EntityFrameworkCore;
using MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.ORM.EF.Repositories
{
    public class LegalClientSampleAnalysisServiceOrderRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.LegalClientSampleAnalysisServiceOrder, long>
    {
        public LegalClientSampleAnalysisServiceOrderRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<LegalClientSampleAnalysisServiceOrder> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Service)
                .Include(entity => entity.Contract).ThenInclude(entity => entity.Client).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.Contract).ThenInclude(entity => entity.Client).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.BusinessKind);
        }
    }
}
