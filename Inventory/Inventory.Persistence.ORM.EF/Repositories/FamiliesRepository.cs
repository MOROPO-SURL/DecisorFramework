namespace MOROPO.Framework.Decisor.Inventory.Persistence.ORM.EF.Repositories
{
    public class FamiliesRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Family, int>
    {
        public FamiliesRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}

