namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display
{
    public class GlobalIndicatorResultDisplayModel : Contract.AbstractIndicatorResultDisplayModel<Persistence.Entities.GlobalIndicatorResult>
    {
        public System.Guid IndicatorId { get; set; }

        public override void Import(Persistence.Entities.GlobalIndicatorResult entity)
        {
            base.Import(entity);

            IndicatorId = entity.IndicatorId;
        }
    }
}
