namespace MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Repositories;

public class ChangeNotificationRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.ChangeNotification, System.Guid>
{
    public ChangeNotificationRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
    {
    }
}
