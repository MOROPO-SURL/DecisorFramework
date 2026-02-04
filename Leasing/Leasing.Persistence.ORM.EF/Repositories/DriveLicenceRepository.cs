namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Repositories;

public class DriveLicenceRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.DriveLicence, System.Guid>
{
    public DriveLicenceRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
    {
    }
}
