namespace MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Repositories
{
    public class PropertyKindRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.PropertyKind, System.Guid>
    {
        public PropertyKindRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
