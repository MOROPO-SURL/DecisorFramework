namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Repositories
{
    public class PurchaseZoneRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.PurchaseZone, System.Guid>
    {
        public PurchaseZoneRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }

        public override System.Func<Entities.PurchaseZone, object> GetPagingOrderSelector()
        {
            return entity => entity.Priority;
        }
    }
}
