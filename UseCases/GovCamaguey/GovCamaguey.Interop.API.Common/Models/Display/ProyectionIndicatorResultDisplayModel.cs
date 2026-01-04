namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display
{
    public class ProyectionIndicatorResultDisplayModel : Contract.AbstractIndicatorResultDisplayModel<Persistence.Entities.ProyectionIndicatorResult>
    {
        public System.Guid IndicatorId { get; set; }

        public override void Import(Persistence.Entities.ProyectionIndicatorResult entity)
        {
            base.Import(entity);

            IndicatorId = entity.IndicatorId;
        }
    }
}
