namespace MOROPO.ISCamaguey.Decisor.Domain.Persistence.ORM.EF.Repositories
{
    public class TechniqueRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Technique, System.Guid>
    {
        public TechniqueRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
