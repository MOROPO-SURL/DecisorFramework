using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Inventory.Persistence.ORM.EF.Configurators
{
    public class ReceptionEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.Contract.AbstractReception>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.Contract.AbstractReception> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.ToTable("receptions");
            entityTypeBuilder.HasDiscriminator();
        }
    }
}
