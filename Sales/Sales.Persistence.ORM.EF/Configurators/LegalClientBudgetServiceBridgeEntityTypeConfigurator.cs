namespace MOROPO.Framework.Decisor.Sales.Persistence.ORM.EF.Configurators
{
    public class LegalClientBudgetServiceBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.LegalClientBudgetServiceBridge>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.LegalClientBudgetServiceBridge> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(bridge => new { bridge.BudgetNumber, bridge.BudgetYear, bridge.ClientId, bridge.ServiceId });

            entityTypeBuilder.HasOne(bridge => bridge.Budget).WithMany(entity => entity.ServiceBridges).HasForeignKey(bridge => new { bridge.BudgetNumber, bridge.BudgetYear, bridge.ClientId });
            entityTypeBuilder.HasOne(bridge => bridge.Service).WithMany().HasForeignKey(bridge => bridge.ServiceId);
        }
    }
}

