using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Financial.Persistence.ORM.EF.Configurators
{
    public class CollectEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.Contract.AbstractCollect>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.Contract.AbstractCollect> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.ToTable("collects", "decisorframework_finantial");
            entityTypeBuilder.HasDiscriminator();
        }
    }
}
