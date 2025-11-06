namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Configurators
{
    public class PurchaseOrderExpectedProductResultEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.PurchaseOrderExpectedProductResult>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.PurchaseOrderExpectedProductResult> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasIndex(entity => new { entity.OrderId, entity.ProductId, entity.ClassificationId }).IsUnique();
        }
    }
}
