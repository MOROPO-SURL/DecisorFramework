using MOROPO.Framework.Decisor.Domain.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Repositories
{
    public class LegalBusinessKindRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<LegalBusinessKind, System.Guid>
    {
        public LegalBusinessKindRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext) { }
    }
}
