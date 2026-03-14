namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Input
{
    public class GlobalIndicatorResultInputModel : Contract.AbstractIndicatorResultInputModel<Persistence.Entities.GlobalIndicatorResult>
    {
        public System.Guid IndicatorId { get; set; }

        public override Persistence.Entities.GlobalIndicatorResult Export()
        {
            var entity = new Persistence.Entities.GlobalIndicatorResult { Id = Id };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.GlobalIndicatorResult entity)
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
