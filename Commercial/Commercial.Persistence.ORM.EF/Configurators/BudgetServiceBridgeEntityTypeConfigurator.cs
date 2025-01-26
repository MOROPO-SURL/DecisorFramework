namespace MOROPO.Framework.Decisor.Commercial.Persistence.ORM.EF.Configurators
{
    public class BudgetServiceBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.BudgetServiceBridge>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.BudgetServiceBridge> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(bridge => new { bridge.BudgetNumber, bridge.BudgetYear, bridge.ServiceId });

            entityTypeBuilder.HasOne(bridge => bridge.Budget).WithMany(entity => entity.ServiceBridges).HasForeignKey(bridge => new { bridge.BudgetNumber, bridge.BudgetYear });
            entityTypeBuilder.HasOne(bridge => bridge.Service).WithMany().HasForeignKey(bridge => bridge.ServiceId);
        }
    }
}

