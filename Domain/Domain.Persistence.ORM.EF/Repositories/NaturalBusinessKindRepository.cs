using MOROPO.Framework.Decisor.Domain.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Repositories
{
    public class NaturalBusinessKindRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<NaturalBusinessKind, System.Guid>
    {
        public NaturalBusinessKindRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext) { }
    }
}
