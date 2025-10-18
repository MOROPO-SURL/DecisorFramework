namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.ORM.EF.Repositories
{
    public class SampleKindRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.SampleKind, System.Guid>
    {
        public SampleKindRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}