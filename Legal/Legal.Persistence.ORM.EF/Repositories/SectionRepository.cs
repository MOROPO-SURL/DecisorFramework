namespace MOROPO.Framework.Decisor.Legal.Persistence.ORM.EF.Repositories
{
    public class SectionRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Section, int>
    {
        public SectionRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
