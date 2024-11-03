namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Configurators
{
    public class PurchaseProductLegalProviderBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.PurchaseProductLegalProviderBridge>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.PurchaseProductLegalProviderBridge> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(bridge => new { bridge.PurchaseId, bridge.ProviderId, bridge.ProductId, bridge.CostCenterId });

            entityTypeBuilder.HasOne(bridge => bridge.Purchase).WithMany(entity => entity.LegalProviderProductBridges).HasForeignKey(bridge => bridge.PurchaseId);
            entityTypeBuilder.HasOne(bridge => bridge.Product).WithMany().HasForeignKey(bridge => bridge.ProductId);
            entityTypeBuilder.HasOne(bridge => bridge.Provider).WithMany().HasForeignKey(bridge => bridge.ProviderId);
            entityTypeBuilder.HasOne(bridge => bridge.CostCenter).WithMany().HasForeignKey(bridge => bridge.CostCenterId);
        }
    }
}
