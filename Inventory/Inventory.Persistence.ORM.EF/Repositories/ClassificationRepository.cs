namespace MOROPO.Framework.Decisor.Inventory.Persistence.ORM.EF.Repositories
{
    public class ClassificationRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Classification, System.Guid>
    {
        public ClassificationRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }

        public override System.Func<Entities.Classification, object> GetPagingOrderSelector()
        {
            return entity => entity.Priority;
        }
    }
}

