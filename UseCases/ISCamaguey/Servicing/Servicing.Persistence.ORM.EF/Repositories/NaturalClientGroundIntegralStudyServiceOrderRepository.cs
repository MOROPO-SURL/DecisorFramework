
using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.ORM.EF.Repositories
{
    public class NaturalClientGroundIntegralStudyServiceOrderRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.NaturalClientGroundIntegralStudyServiceOrder, long>
    {
        public NaturalClientGroundIntegralStudyServiceOrderRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.NaturalClientGroundIntegralStudyServiceOrder> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Service)
                .Include(entity => entity.Contract).ThenInclude(entity => entity.Client).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.Contract).ThenInclude(entity => entity.Client).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.BusinessKind);
        }
    }
}
