namespace MOROPO.Framework.Decisor.Commercial.Persistence.ORM.EF.Repositories
{
    public class LegalBusinessKindRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.LegalBusinessKind, System.Guid>
    {
        public LegalBusinessKindRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext) { }

        public override System.Func<Entities.LegalBusinessKind, object> GetPagingOrderSelector()
        {
            return entity => entity.Priority;
        }
    }
}
