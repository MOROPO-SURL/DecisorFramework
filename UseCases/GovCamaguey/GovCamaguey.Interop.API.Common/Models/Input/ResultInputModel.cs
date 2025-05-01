namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Input
{
    public class ResultInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Result, long>
    {
        public long Id { get; set; }

        public System.Guid IndicatorId { get; set; }

        public double Amount { get; set; }

        public Persistence.Entities.Result Export()
        {
            var entity = new Persistence.Entities.Result { Id = Id };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Result entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Result entity)
        {
            entity.Amount = Amount;

            if (entity.IndicatorId != IndicatorId)
            {
                entity.Indicator = null;
                entity.IndicatorId = IndicatorId;
            }
        }
    }
}
