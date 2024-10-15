namespace MOROPO.Framework.Decisor.Essential.Persistence.ORM.EF.Repositories
{
    public class UnitMeasurementRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.UnitMeasurement, System.Guid>
    {
        public UnitMeasurementRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }

        public override System.Func<Entities.UnitMeasurement, object> GetPagingOrderSelector()
        {
            return entity => entity.Priority;
        }
    }
}
