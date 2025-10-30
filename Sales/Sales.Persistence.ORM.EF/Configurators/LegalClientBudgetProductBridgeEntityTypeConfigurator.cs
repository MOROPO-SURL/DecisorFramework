namespace MOROPO.Framework.Decisor.Sales.Persistence.ORM.EF.Configurators
{
    public class LegalClientBudgetProductBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.LegalClientBudgetProductBridge>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.LegalClientBudgetProductBridge> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(bridge => new { bridge.BudgetNumber, bridge.BudgetYear, bridge.ClientId, bridge.ProductId, bridge.ClassificationId });

            entityTypeBuilder.HasOne(bridge => bridge.Budget).WithMany(entity => entity.ProductBridges).HasForeignKey(bridge => new { bridge.BudgetNumber, bridge.BudgetYear, bridge.ClientId });
            entityTypeBuilder.HasOne(bridge => bridge.Product).WithMany().HasForeignKey(bridge => bridge.ProductId);
        }
    }
}

