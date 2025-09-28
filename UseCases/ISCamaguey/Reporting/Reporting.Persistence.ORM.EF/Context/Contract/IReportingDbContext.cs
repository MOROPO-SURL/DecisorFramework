using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.Reporting.Persistence.ORM.EF.Context.Contract
{
    public interface IReportingDbContext : Lab.Persistence.ORM.EF.Context.Contract.ILabDbContext
    {
        public DbSet<Entities.SampleAnalysisReport> SampleAnalysisReports { get; set; }
        public DbSet<Entities.SampleAnalysisServiceReport> SampleAnalysisServiceReports { get; set; }
    }
}