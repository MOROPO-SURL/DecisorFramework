namespace MOROPO.Framework.Decisor.Commercial.Persistence.ORM.EF.Configurators
{
    public class BudgetProductBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.BudgetProductBridge>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.BudgetProductBridge> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(bridge => new { bridge.BudgetNumber, bridge.BudgetYear, bridge.ProductId });

            entityTypeBuilder.HasOne(bridge => bridge.Budget).WithMany(entity => entity.ProductBridges).HasForeignKey(bridge => new { bridge.BudgetNumber, bridge.BudgetYear });
            entityTypeBuilder.HasOne(bridge => bridge.Product).WithMany().HasForeignKey(bridge => bridge.ProductId);
        }
    }
}

