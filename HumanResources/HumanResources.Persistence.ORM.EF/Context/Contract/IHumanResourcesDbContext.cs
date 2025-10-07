using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.HumanResources.Persistence.ORM.EF.Context.Contract
{
    public interface IHumanResourcesDbContext : Legal.Persistence.ORM.EF.Context.Contract.ILegalDbContext
    {
        public DbSet<Entities.Schooling> Schoolings { get; set; }
        public DbSet<Entities.SalaryStandard> SalaryStandards { get; set; }
        public DbSet<Entities.WorkPositionKind> WorkPositionKinds { get; set; }
        public DbSet<Entities.WorkPosition> WorkPositions { get; set; }
        public DbSet<Entities.WorkPositionResponsability> WorkPositionResponsabilities { get; set; }
        public DbSet<Entities.Workforce> Workforces { get; set; }
        public DbSet<Entities.WorkforceOrganizationalUnity> WorkforceOrganizationalUnities { get; set; }
        public DbSet<Entities.Vacant> Vacants { get; set; }
        public DbSet<Entities.VacantPostulation> VacantPostulations { get; set; }
        public DbSet<Entities.VacantPostulationOcupation> VacantPostulationOcupations { get; set; }
        public DbSet<Entities.VacantPostulationDocumentBridge> VacantPostulationDocumentBridges { get; set; }
        public DbSet<Entities.OcupationCandidate> OcupationCandidates { get; set; }
        public DbSet<Entities.AdmitionPropousal> AdmitionPropousals { get; set; }
        public DbSet<Entities.Contract.AbstractEmploymentContract> EmploymentContracts { get; set; }
        public DbSet<Entities.NamingEmploymentContract> NamingEmploymentContracts { get; set; }
        public DbSet<Entities.AdmitionEmploymentContract> AdmitionEmploymentContracts { get; set; }
        public DbSet<Entities.NamingResolution> NamingResolutions { get; set; }
        public DbSet<Entities.RemotionResolution> RemotionResolutions { get; set; }
        public DbSet<Entities.Staff> Staffs { get; set; }
        public DbSet<Entities.StaffWorkforceBridge> StaffWorkforceBridges { get; set; }
        public DbSet<Entities.Ocupation> Ocupations { get; set; }
    }
}
