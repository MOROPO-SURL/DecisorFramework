namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Configurators
{
    public class PurchaseProductNaturalProviderBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.PurchaseProductNaturalProviderBridge>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.PurchaseProductNaturalProviderBridge> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(bridge => new { bridge.PurchaseId, bridge.ProviderId, bridge.ProductId, bridge.CostCenterId });

            entityTypeBuilder.HasOne(bridge => bridge.Purchase).WithMany(entity => entity.NaturalProviderProductBridges).HasForeignKey(bridge => bridge.PurchaseId);
            entityTypeBuilder.HasOne(bridge => bridge.Product).WithMany().HasForeignKey(bridge => bridge.ProductId);
            entityTypeBuilder.HasOne(bridge => bridge.Provider).WithMany().HasForeignKey(bridge => bridge.ProviderId);
            entityTypeBuilder.HasOne(bridge => bridge.CostCenter).WithMany().HasForeignKey(bridge => bridge.CostCenterId);
        }
    }
}
