namespace MOROPO.Framework.Decisor.Commercial.Persistence.ORM.EF.Repositories
{
    public class NaturalBusinessKindRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.NaturalBusinessKind, System.Guid>
    {
        public NaturalBusinessKindRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext) { }
    }
}
