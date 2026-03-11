namespace MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Repositories;

public class AcademicAchievementRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.AcademicAchievement, System.Guid>
{
    public AcademicAchievementRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
    {
    }
}