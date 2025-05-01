namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display
{
    public class IndicatorDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Indicator, System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public UnitMeasurementDisplayModel UnitMeasurement { get; set; }

        public double Amount { get; set; }

        public double Balance { get; set; }

        public void Import(Persistence.Entities.Indicator entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            Name = entity.Name;
            Description = entity.Description;
            Amount = entity.Amount;

            if (entity.UnitMeasurement != null)
            {
                UnitMeasurement = new UnitMeasurementDisplayModel();

                UnitMeasurement.Import(entity.UnitMeasurement);
            }
        }
    }
}
