namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Input
{
    public class ObjectiveIndicatorResultInputModel : Contract.AbstractIndicatorResultInputModel<Persistence.Entities.ObjectiveIndicatorResult>
    {
        public System.Guid IndicatorId { get; set; }

        public override Persistence.Entities.ObjectiveIndicatorResult Export()
        {
            var entity = new Persistence.Entities.ObjectiveIndicatorResult { Id = Id };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.ObjectiveIndicatorResult entity)
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
