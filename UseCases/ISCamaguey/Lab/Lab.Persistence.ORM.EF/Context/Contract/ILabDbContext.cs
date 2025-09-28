using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.ORM.EF.Context.Contract
{
    public interface ILabDbContext : Servicing.Persistence.ORM.EF.Context.Contract.IServicingDbContext, IDi.Persistence.ORM.EF.Context.Contract.IIDiDbContext
    {
        public DbSet<Entities.Analysis> Analysises { get; set; }
        public DbSet<Entities.AnalysisOrder> AnalysisOrders { get; set; }
        public DbSet<Entities.Assessment> Assessments { get; set; }
        // TODO Uncomment required line!!
        //public DbSet<Entities.ProductionSample> ProductionSamples { get; set; }
        public DbSet<Entities.ResearchSample> ResearchSamples { get; set; }
        public DbSet<Entities.SampleKind> SampleKinds { get; set; }
        public DbSet<Entities.ServiceOrderSample> ServiceOrderSamples { get; set; }
        public DbSet<Entities.WorkingGroup> WorkingGroups { get; set; }
        public DbSet<Entities.WorkingGroupEmployeeBridge> WorkingGroupEmployeeBridges { get; set; }
        public DbSet<Entities.WorkingGroupTechniqueBridge> WorkingGroupTechniqueBridges { get; set; }
        public DbSet<Entities.WorkPlan> WorkPlans { get; set; }
    }
}