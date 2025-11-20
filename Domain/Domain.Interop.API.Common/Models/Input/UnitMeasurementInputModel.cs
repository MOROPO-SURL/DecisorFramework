using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input
{
    public class UnitMeasurementInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.UnitMeasurement, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Symbol { get; set; }

        public int Priority { get; set; }

        public List<Bridge.UnitMeasurementConvertionBridgeModel> EditionConvertions { get; set; } = new List<Bridge.UnitMeasurementConvertionBridgeModel>();
        public List<Bridge.UnitMeasurementConvertionBridgeModel> IncomingConvertions { get; set; } = new List<Bridge.UnitMeasurementConvertionBridgeModel>();
        public List<Bridge.UnitMeasurementConvertionBridgeModel> OutgoingConvertions { get; set; } = new List<Bridge.UnitMeasurementConvertionBridgeModel>();

        public Persistence.Entities.UnitMeasurement Export()
        {
            var entity = new Persistence.Entities.UnitMeasurement
            {
                Id = Id,
                Enabled = true
            };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.UnitMeasurement entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.UnitMeasurement entity)
        {
            entity.Name = Name;
            entity.Symbol = Symbol;
            entity.Priority = Priority;
        }
    }
}
