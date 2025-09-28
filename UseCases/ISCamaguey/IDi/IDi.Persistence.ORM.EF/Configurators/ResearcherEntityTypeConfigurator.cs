using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Configurators
{
    public class ResearcherEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.Contract.AbstractResearcher>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.Contract.AbstractResearcher> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.ToTable("researchers", "decisoriscamaguey_idi");
            entityTypeBuilder.HasDiscriminator();
        }
    }
}
