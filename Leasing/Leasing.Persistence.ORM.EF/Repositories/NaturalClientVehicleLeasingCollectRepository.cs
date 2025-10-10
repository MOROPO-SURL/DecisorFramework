using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Repositories
{
    public class NaturalClientVehicleLeasingCollectRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.NaturalClientVehicleLeasingCollect, System.Guid>
    {
        public NaturalClientVehicleLeasingCollectRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.NaturalClientVehicleLeasingCollect> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Leasing).ThenInclude(entity => entity.CostCenter).ThenInclude(entity => entity.Structure).ThenInclude(entity => entity.Identity)
                .Include(entity => entity.Leasing).ThenInclude(entity => entity.CostCenter).ThenInclude(entity => entity.DefaultBankAccount).ThenInclude(entity => entity.Currency)
                .Include(entity => entity.Leasing).ThenInclude(entity => entity.Contract).ThenInclude(entity => entity.Client).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.Leasing).ThenInclude(entity => entity.Contract).ThenInclude(entity => entity.Client).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.BusinessKind)
                .Include(entity => entity.Leasing).ThenInclude(entity => entity.Contract).ThenInclude(entity => entity.Postulation).ThenInclude(entity => entity.Offer).ThenInclude(entity => entity.Propousal).ThenInclude(entity => entity.Vehicle).ThenInclude(entity => entity.FeatureImage)
                .Include(entity => entity.Leasing).ThenInclude(entity => entity.Contract).ThenInclude(entity => entity.Postulation).ThenInclude(entity => entity.Offer).ThenInclude(entity => entity.Propousal).ThenInclude(entity => entity.Vehicle).ThenInclude(entity => entity.Brand)
                .Include(entity => entity.Leasing).ThenInclude(entity => entity.Contract).ThenInclude(entity => entity.Postulation).ThenInclude(entity => entity.Offer).ThenInclude(entity => entity.Propousal).ThenInclude(entity => entity.Vehicle).ThenInclude(entity => entity.Kind);
        }
    }
}