namespace MOROPO.Framework.Decisor.HumanResources.Persistence.ORM.EF.Context.Contract
{
    public interface IHumanResourcesDbContext : Legal.Persistence.ORM.EF.Context.Contract.ILegalDbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Entities.Schooling> Schoolings { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.VacantKind> VacantKinds { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.Vacant> Vacants { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.SalaryStandard> SalaryStandards { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.Workforce> Workforces { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.WorkforceOrganizationalUnityVacantBridge> WorkforceOrganizationalUnityVacantBridge { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.Employee> Employees { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.EmploymentContract> EmploymentContracts { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.NamingResolution> NamingResolutions { get; set; }
    }
}
