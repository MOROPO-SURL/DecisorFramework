using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.ORM.EF.Configurators
{
    public class ServiceOrderEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.Contract.AbstractServiceOrder>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.Contract.AbstractServiceOrder> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.ToTable("serviceorders", "decisoriscamaguey_servicing");
            entityTypeBuilder.HasDiscriminator();
        }

    }
}
