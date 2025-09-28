using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.ORM.EF.Context.Contract
{
    public interface IServicingDbContext : Domain.Persistence.ORM.EF.Context.Contract.IDomainDbContext
    {
        public DbSet<Entities.TrainingService> TrainingServices { get; set; }
        public DbSet<Entities.SampleAnalysisService> SampleAnalysisServices { get; set; }   
        public DbSet<Entities.LegalClientTrainingServiceOrder> LegalClientTrainingServiceOrders { get; set; }
        public DbSet<Entities.LegalClientSampleAnalysisServiceOrder> LegalClientSampleAnalysisServiceOrders { get; set; }
        public DbSet<Entities.NaturalClientTrainingServiceOrder> NaturalClientTrainingServiceOrders { get; set; }
        public DbSet<Entities.NaturalClientSampleAnalysisServiceOrder> NaturalClientSampleAnalysisServiceOrders { get; set; }
        public DbSet<Entities.ServiceOrderCollect> ServiceOrderCollects { get; set; }
    }
}