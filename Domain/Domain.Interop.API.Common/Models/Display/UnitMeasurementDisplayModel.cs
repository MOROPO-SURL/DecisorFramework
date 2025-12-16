using System.Linq;

namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display
{
    public class UnitMeasurementDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.UnitMeasurement, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }

        public System.DateTime At { get; set; }

        public int Priority { get; set; }

        public Bridge.UnitMeasurementConvertionBridgeModel[] ConverstionBridges { get; set; }

        public void Import(Persistence.Entities.UnitMeasurement entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Symbol = entity.Symbol;
            Priority = entity.Priority;
            At = entity.At;
            ConverstionBridges = entity.ConversionBridges.Select(bridge =>
            {
                var model = new Bridge.UnitMeasurementConvertionBridgeModel
                {
                    Destination = new UnitMeasurementDisplayModel
                    {
                        Id = bridge.SternId,
                        Name = bridge.Stern.Name,
                        Symbol = bridge.Stern.Symbol,
                        At = bridge.Stern.At,
                        Priority = bridge.Stern.Priority
                    },
                    Convertion = bridge.Convertion
                };

                return model;
            }).ToArray();
        }
    }
}
