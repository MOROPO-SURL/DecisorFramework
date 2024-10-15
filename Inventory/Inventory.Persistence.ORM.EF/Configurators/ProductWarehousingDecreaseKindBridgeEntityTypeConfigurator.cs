namespace MOROPO.Framework.Decisor.Inventory.Persistence.ORM.EF.Configurators
{
    public class ProductWarehousingDecreaseKindBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.ProductWarehousingDecreaseKindBridge>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.ProductWarehousingDecreaseKindBridge> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(bridge => new { bridge.Kind, bridge.ProductId });

            entityTypeBuilder.HasOne(bridge => bridge.Product).WithMany(entity => entity.WarehousingDecreaseKindBridges).HasForeignKey(bridge => bridge.ProductId);
        }
    }
}
