namespace MOROPO.Framework.Decisor.Legal.Persistence.ORM.EF.Repositories
{
    public class SectionRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Section, System.Guid>
    {
        public SectionRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
