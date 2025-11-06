namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Repositories
{
    public class PurchaseOrderPlannedProductSpentRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.PurchaseOrderPlannedProductSpent, System.Guid>
    {
        public PurchaseOrderPlannedProductSpentRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
