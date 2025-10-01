namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Repositories
{
    public class ProgramExpectResultRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.ProgramExpectResult, System.Guid>
    {
        public ProgramExpectResultRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
