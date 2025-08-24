using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Legal.Persistence.ORM.EF.Configurators
{
    public class ResolutionEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.Contract.AbstractResolution>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.Contract.AbstractResolution> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.ToTable("resolutions");
            entityTypeBuilder.HasDiscriminator();
        }
    }
}
