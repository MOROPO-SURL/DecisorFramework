namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Persistence.ORM.EF.Configurators;

public sealed class ObjectiveIndicatorEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Prototype.Persistence.Entities.ObjectiveIndicator>
{
    protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Prototype.Persistence.Entities.ObjectiveIndicator> entityTypeBuilder)
    {
        base.ApplayRules(entityTypeBuilder);

        entityTypeBuilder.HasOne(entity => entity.UnitMeasurement).WithMany().HasForeignKey(entity => entity.UnitMeasurementId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
    }
}
