namespace MOROPO.Framework.Decisor.Inventory.Persistence.ORM.EF.Repositories
{
    public class WarehouseRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Warehouse, System.Guid>
    {
        public WarehouseRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }

        public override System.Func<Entities.Warehouse, object> GetPagingOrderSelector()
        {
            return entity => entity.Priority;
        }
    }
}
