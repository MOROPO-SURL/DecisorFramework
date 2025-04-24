namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display
{
    public class UnitMeasurementDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.UnitMeasurement, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }

        public System.DateTime At { get; set; }

        public int Priority { get; set; }

        public void Import(Persistence.Entities.UnitMeasurement entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Symbol = entity.Symbol;
            Priority = entity.Priority;
        }
    }
}
