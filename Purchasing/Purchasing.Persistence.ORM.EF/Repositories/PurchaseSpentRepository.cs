namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Repositories
{
    public class PurchaseSpentRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.PurchaseSpent, System.Guid>
    {
        public PurchaseSpentRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }

        public override System.Func<Entities.PurchaseSpent, object> GetPagingOrderSelector()
        {
            return entity => entity.Priority;
        }
    }
}
