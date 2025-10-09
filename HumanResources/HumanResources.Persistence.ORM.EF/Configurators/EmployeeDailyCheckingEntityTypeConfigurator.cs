namespace MOROPO.Framework.Decisor.HumanResources.Persistence.ORM.EF.Configurators
{
    public class EmployeeDailyCheckingEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.EmployeeDailyChecking>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.EmployeeDailyChecking> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasIndex(entity => new { entity.EmployeeId, entity.Day, entity.Month, entity.Year }).IsUnique();
        }
    }
}
