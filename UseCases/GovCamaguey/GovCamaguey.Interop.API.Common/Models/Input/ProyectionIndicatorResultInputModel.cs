namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Input
{
    public class ProyectionIndicatorResultInputModel : Contract.AbstractIndicatorResultInputModel<Persistence.Entities.ProyectionIndicatorResult>
    {
        public System.Guid IndicatorId { get; set; }

        public override Persistence.Entities.ProyectionIndicatorResult Export()
        {
            var entity = new Persistence.Entities.ProyectionIndicatorResult { Id = Id };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.ProyectionIndicatorResult entity)
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
