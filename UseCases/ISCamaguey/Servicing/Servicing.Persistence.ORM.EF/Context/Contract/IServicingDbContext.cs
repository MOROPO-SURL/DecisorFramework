using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.ORM.EF.Context.Contract
{
    public interface IServicingDbContext : Domain.Persistence.ORM.EF.Context.Contract.IDomainDbContext, Framework.Decisor.Commercial.Persistence.ORM.EF.Context.Contract.ICommercialDbContext, Framework.Decisor.HumanResources.Persistence.ORM.EF.Context.Contract.IHumanResourcesDbContext
    {
        public DbSet<Entities.TrainingService> TrainingServices { get; set; }
        public DbSet<Entities.TrainingServiceEmployeeBridge> TrainingServiceEmployeeBridges { get; set; }
        public DbSet<Entities.TrainingServiceDocumentBridge> TrainingServiceDocumentBridges { get; set; }
        public DbSet<Entities.TrainingServiceStep> TrainingServSteps { get; set; }
        public DbSet<Entities.TrainingServiceStepWorkPositionBridge> TrainingServStepWorkPosBridges { get; set; }
        public DbSet<Entities.SampleAnalysisService> SampleAnalysisServices { get; set; }
        public DbSet<Entities.SampleAnalysisServiceEmployeeBridge> SampleAnalysisServiceEmployeeBridges { get; set; }
        public DbSet<Entities.SampleAnalysisServiceDocumentBridge> SampleAnalysisServiceDocumentBridges { get; set; }
        public DbSet<Entities.SampleAnalysisServiceStep> SampAnalServSteps { get; set; }
        public DbSet<Entities.SampleAnalysisServiceStepWorkPositionBridge> SampAnalServStepWorkPosBridges { get; set; }
        public DbSet<Entities.GroundIntegralStudyService> GroundIntegralStudyServices { get; set; }
        public DbSet<Entities.GroundIntegralStudyServiceEmployeeBridge> GroundIntegralStudyServiceEmployeeBridges { get; set; }
        public DbSet<Entities.GroundIntegralStudyServiceDocumentBridge> GroundIntegralStudyServiceDocumentBridges { get; set; }
        public DbSet<Entities.GroundIntegralStudyServiceStep> GroundIntStudyServSteps { get; set; }
        public DbSet<Entities.GroundIntegralStudyServiceStepWorkPositionBridge> GroundIntStudyServStepWorkPosBridges { get; set; }
        public DbSet<Entities.LegalClientTrainingServiceOrder> LegalClientTrainingServiceOrders { get; set; }
        public DbSet<Entities.LegalClientSampleAnalysisServiceOrder> LegalClientSampleAnalysisServiceOrders { get; set; }
        public DbSet<Entities.LegalClientGroundIntegralStudyServiceOrder> LegalClientGroundIntegralStudyServiceOrders { get; set; }
        public DbSet<Entities.NaturalClientTrainingServiceOrder> NaturalClientTrainingServiceOrders { get; set; }
        public DbSet<Entities.NaturalClientSampleAnalysisServiceOrder> NaturalClientSampleAnalysisServiceOrders { get; set; }
        public DbSet<Entities.NaturalClientGroundIntegralStudyServiceOrder> NaturalClientGroundIntegralStudyServiceOrders { get; set; }
        public DbSet<Entities.ServiceOrderCollect> ServiceOrderCollects { get; set; }
    }
}