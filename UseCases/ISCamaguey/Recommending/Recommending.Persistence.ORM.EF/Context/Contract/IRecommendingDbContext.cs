using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.Recommending.Persistence.ORM.EF.Context.Contract;

public interface IRecommendingDbContext
{
    DbSet<Entities.RecomendationReport> RecomendationReports { get; set; }

    DbSet<Entities.RecomendationReportEmployeeBridge> RecomendationReportEmployeeBridges { get; set; }
}