namespace MOROPO.Framework.Decisor.Legal.Persistence.ORM.EF.Repositories
{
    public class TagRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Tag, string>
    {
        public TagRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
