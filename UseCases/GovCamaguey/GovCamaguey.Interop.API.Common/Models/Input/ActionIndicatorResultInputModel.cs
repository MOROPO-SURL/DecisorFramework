namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Input
{
    public class ActionIndicatorResultInputModel : Contract.AbstractIndicatorResultInputModel<Persistence.Entities.ActionIndicatorResult>
    {
        public System.Guid IndicatorId { get; set; }

        public override Persistence.Entities.ActionIndicatorResult Export()
        {
            var entity = new Persistence.Entities.ActionIndicatorResult { Id = Id };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.ActionIndicatorResult entity)
        {
            base.Mergue(entity);

            if (entity.IndicatorId != IndicatorId)
            {
                entity.Indicator = null;
                entity.IndicatorId = IndicatorId;
            }
        }
    }
}
