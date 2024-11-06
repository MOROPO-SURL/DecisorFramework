namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Configurators
{
    public class PurchaseReceptionProductWeightBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.PurchaseReceptionProductWeightBridge>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.PurchaseReceptionProductWeightBridge> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(bridge => new { bridge.ReceptionId, bridge.ProductId, bridge.CostCenterId });

            entityTypeBuilder.HasOne(bridge => bridge.Reception).WithMany(entity => entity.ProductWeightBridges).HasForeignKey(bridge => bridge.ReceptionId);
            entityTypeBuilder.HasOne(bridge => bridge.Product).WithMany().HasForeignKey(bridge => bridge.ProductId);
            entityTypeBuilder.HasOne(bridge => bridge.CostCenter).WithMany().HasForeignKey(bridge => bridge.CostCenterId); 
        }
    }
}
