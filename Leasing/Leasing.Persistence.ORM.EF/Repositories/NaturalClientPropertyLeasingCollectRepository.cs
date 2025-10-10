using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Repositories
{
    public class NaturalClientPropertyLeasingCollectRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.NaturalClientPropertyLeasingCollect, System.Guid>
    {
        public NaturalClientPropertyLeasingCollectRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.NaturalClientPropertyLeasingCollect> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Leasing).ThenInclude(entity => entity.CostCenter).ThenInclude(entity => entity.Structure).ThenInclude(entity => entity.Identity)
                .Include(entity => entity.Leasing).ThenInclude(entity => entity.CostCenter).ThenInclude(entity => entity.DefaultBankAccount).ThenInclude(entity => entity.Currency)
                .Include(entity => entity.Leasing).ThenInclude(entity => entity.Contract).ThenInclude(entity => entity.Client).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.Leasing).ThenInclude(entity => entity.Contract).ThenInclude(entity => entity.Client).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.BusinessKind)
                .Include(entity => entity.Leasing).ThenInclude(entity => entity.Contract).ThenInclude(entity => entity.Postulation).ThenInclude(entity => entity.Offer).ThenInclude(entity => entity.Propousal).ThenInclude(entity => entity.Property).ThenInclude(entity => entity.FeatureImage)
                .Include(entity => entity.Leasing).ThenInclude(entity => entity.Contract).ThenInclude(entity => entity.Postulation).ThenInclude(entity => entity.Offer).ThenInclude(entity => entity.Propousal).ThenInclude(entity => entity.Property).ThenInclude(entity => entity.Kind);
        }
    }
}
