namespace MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Repositories
{
    public class VehicleEngineKindRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.VehicleEngineKind, System.Guid>
    {
        public VehicleEngineKindRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
