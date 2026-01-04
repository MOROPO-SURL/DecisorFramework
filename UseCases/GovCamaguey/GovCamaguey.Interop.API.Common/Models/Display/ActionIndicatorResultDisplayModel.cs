namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display
{
    public class ActionIndicatorResultDisplayModel : Contract.AbstractIndicatorResultDisplayModel<Persistence.Entities.ActionIndicatorResult>
    {
        public System.Guid IndicatorId { get; set; }

        public override void Import(Persistence.Entities.ActionIndicatorResult entity)
        {
            base.Import(entity);

            IndicatorId = entity.IndicatorId;
        }
    }
}