
namespace MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Repositories
{
    public class KnowledgeAreaRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.KnowledgeArea, System.Guid>
    {
        public KnowledgeAreaRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
