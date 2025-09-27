namespace MOROPO.ISCamaguey.Decisor.Quality.Persistence.ORM.EF.Repositories
{
    public class CubanStandardRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.CubanStandard, int>
    {
        public CubanStandardRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}