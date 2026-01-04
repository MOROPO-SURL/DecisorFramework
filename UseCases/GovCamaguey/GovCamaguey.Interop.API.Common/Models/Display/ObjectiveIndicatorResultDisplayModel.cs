namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display
{
    public class ObjectiveIndicatorResultDisplayModel : Contract.AbstractIndicatorResultDisplayModel<Persistence.Entities.ObjectiveIndicatorResult>
    {
        public System.Guid IndicatorId { get; set; }

        public override void Import(Persistence.Entities.ObjectiveIndicatorResult entity)
        {
            base.Import(entity);

            IndicatorId = entity.IndicatorId;
        }
    }
}
