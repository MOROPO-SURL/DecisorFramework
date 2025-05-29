namespace MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Repositories
{
    public class BrandRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Brand, System.Guid>
    {
        public BrandRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}