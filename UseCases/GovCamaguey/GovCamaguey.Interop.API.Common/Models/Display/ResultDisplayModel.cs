namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display
{
    public class ResultDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Result, long>
    {
        public long Id { get; set; }

        public System.DateTime At { get; set; }

        public System.Guid IndicatorId { get; set; }

        public double Amount { get; set; }

        public void Import(Persistence.Entities.Result entity)
        {
            Id = entity.Id;
            At = entity.At;
            Amount = entity.Amount;
            IndicatorId = entity.IndicatorId;
        }
    }
}
