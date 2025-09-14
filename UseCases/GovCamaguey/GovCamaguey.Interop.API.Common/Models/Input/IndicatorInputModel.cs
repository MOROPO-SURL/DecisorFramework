using System.Collections.Generic;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Input
{
    public class IndicatorInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Indicator, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public System.Guid UnitMeasurementId { get; set; }

        public double Amount { get; set; }

        public List<IndicatorMontlyPlanInputModel> EditionMontlyPlans { get; set; } = new List<IndicatorMontlyPlanInputModel>();
        public List<IndicatorMontlyPlanInputModel> IncomingMontlyPlans { get; set; } = new List<IndicatorMontlyPlanInputModel>();
        public List<Display.IndicatorMontlyPlanDisplayModel> OutgoingMontlyPlans { get; set; } = new List<Display.IndicatorMontlyPlanDisplayModel>();

        public Persistence.Entities.Indicator Export()
        {
            var entity = new Persistence.Entities.Indicator { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Indicator entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Indicator entity)
        {
            entity.Priority = Priority;
            entity.Name = Name;
            entity.Description = Description;
            entity.Amount = Amount;

            if (entity.UnitMeasurementId != UnitMeasurementId)
            {
                entity.UnitMeasurement = null;
                entity.UnitMeasurementId = UnitMeasurementId;
            }
        }
    }
}
