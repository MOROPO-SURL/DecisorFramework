namespace MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Repositories
{
    public class StructureKindRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.StructureKind, System.Guid>
    {
        public StructureKindRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
