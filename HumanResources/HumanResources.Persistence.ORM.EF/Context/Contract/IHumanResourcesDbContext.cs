namespace MOROPO.Framework.Decisor.HumanResources.Persistence.ORM.EF.Context.Contract
{
    public interface IHumanResourcesDbContext : Legal.Persistence.ORM.EF.Context.Contract.ILegalDbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Entities.Employee> Employees { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.EmploymentContract> EmploymentContracts { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.NamingResolution> NamingResolutions { get; set; }
    }
}
