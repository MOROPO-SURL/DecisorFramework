namespace MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Configurators
{
    public class VehicleEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.Vehicle>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.Vehicle> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasIndex(entity => entity.Plate).IsUnique();
            entityTypeBuilder.HasIndex(entity => entity.TrafficCirculationIdentifier).IsUnique();
            entityTypeBuilder.HasIndex(entity => entity.EngineIdentifier).IsUnique();
            entityTypeBuilder.HasIndex(entity => entity.BodyIdentifier).IsUnique();
        }
    }
}
