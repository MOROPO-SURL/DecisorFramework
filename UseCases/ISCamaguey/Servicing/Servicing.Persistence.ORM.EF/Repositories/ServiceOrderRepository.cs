namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.ORM.EF.Repositories;

public sealed class ServiceOrderRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Contract.AbstractServiceOrder, long>
{
    public ServiceOrderRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
    {
    }
}