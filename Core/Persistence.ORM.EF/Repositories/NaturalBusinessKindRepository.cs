namespace MOROPO.Framework.Decisor.Core.Persistence.ORM.EF.Repositories
{
    public class NaturalBusinessKindRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.NaturalBusinessKind, System.Guid>
    {
        public NaturalBusinessKindRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext) { }

        public override System.Func<Entities.NaturalBusinessKind, object> GetPagingOrderSelector()
        {
            return entity => entity.Priority;
        }
    }
}
