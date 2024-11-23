namespace MOROPO.Framework.Decisor.HumanResources.Persistence.ORM.EF.Context.Contract
{
    public interface IHumanResourcesDbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Entities.Employee> Employees { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.EmploymentContract> EmploymentContracts { get; set; }
    }
}
