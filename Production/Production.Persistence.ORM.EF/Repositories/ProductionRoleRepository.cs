namespace MOROPO.Framework.Decisor.Production.Persistence.ORM.EF.Repositories
{
    public class ProductionRoleRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.ProductionRole, System.Guid>
    {
        public ProductionRoleRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }

        public override System.Func<Entities.ProductionRole, object> GetPagingOrderSelector()
        {
            return entity => entity.Priority;
        }
    }
}

