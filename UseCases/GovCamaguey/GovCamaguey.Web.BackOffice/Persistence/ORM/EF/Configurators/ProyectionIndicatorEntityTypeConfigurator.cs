namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Persistence.ORM.EF.Configurators;

public sealed class ProyectionIndicatorEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Prototype.Persistence.Entities.ProyectionIndicator>
{
    protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Prototype.Persistence.Entities.ProyectionIndicator> entityTypeBuilder)
    {
        base.ApplayRules(entityTypeBuilder);

        entityTypeBuilder.HasOne(entity => entity.UnitMeasurement).WithMany().HasForeignKey(entity => entity.UnitMeasurementId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
    }
}
