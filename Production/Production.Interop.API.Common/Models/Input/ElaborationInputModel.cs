using System.Linq;

namespace MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Input
{
    public class ElaborationInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Elaboration, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        public System.Guid ProductId { get; set; }

        public System.Guid? ClassificationId { get; set; }

        public string Description { get; set; }

        public System.Guid? ReferenceCurrencyId { get; set; }

        public decimal MinPerformanceCoefficient { get; set; }

        public decimal MaxPerformanceCoefficient { get; set; }

        //public List<ElaborationStepDisplayModel> EditionSteps { get; set; } = new List<ElaborationStepDisplayModel>();
        //public List<ElaborationStepDisplayModel> IncomingSteps { get; set; } = new List<ElaborationStepDisplayModel>();
        //public List<ElaborationStepDisplayModel> OutgoingSteps { get; set; } = new List<ElaborationStepDisplayModel>();

        public System.Collections.Generic.List<Display.ElaborationStepDisplayModel> Steps { get; set; } = new System.Collections.Generic.List<Display.ElaborationStepDisplayModel>();

        public System.Collections.Generic.List<Bridge.CommonElaborationProductBridgeModel> InputProductBridges { get; set; } = new System.Collections.Generic.List<Bridge.CommonElaborationProductBridgeModel>();

        public System.Collections.Generic.List<Bridge.CommonElaborationProductBridgeModel> OutputProductBridges { get; set; } = new System.Collections.Generic.List<Bridge.CommonElaborationProductBridgeModel>();

        public Persistence.Entities.Elaboration Export()
        {
            var entity = new Persistence.Entities.Elaboration { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Elaboration entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Elaboration entity)
        {
            entity.Priority = Priority;
            entity.Description = Description;
            entity.MinPerformanceCoefficient = MinPerformanceCoefficient;
            entity.MaxPerformanceCoefficient = MaxPerformanceCoefficient;
            entity.InputProductBridges = InputProductBridges.Where(model => model.Classification == null).Select(model => new Persistence.Entities.ElaborationInputProductBridge
            {
                ProwId = entity.Id,
                SternId = model.Product.Id,
                Amount = model.Amount,
                UnitMeasurementId = model.UnitMeasurement.Id
            }).ToList();
            entity.InputProductClassificationBridges = InputProductBridges.Where(model => model.Classification != null).Select(model => new Persistence.Entities.ElaborationInputProductClassificationBridge
            {
                ProwId = entity.Id,
                SternId = model.Classification.Id,
                Amount = model.Amount,
                UnitMeasurementId = model.UnitMeasurement.Id,
            }).ToList();
            entity.OutputProductBridges = OutputProductBridges.Where(model => model.Classification == null).Select(model => new Persistence.Entities.ElaborationOutputProductBridge
            {
                ProwId = entity.Id,
                SternId = model.Product.Id,
                Amount = model.Amount,
                UnitMeasurementId = model.UnitMeasurement.Id
            }).ToList();
            entity.OutputProductClassificationBridges = OutputProductBridges.Where(model => model.Classification != null).Select(model => new Persistence.Entities.ElaborationOutputProductClassificationBridge
            {
                ProwId = entity.Id,
                SternId = model.Classification.Id,
                Amount = model.Amount,
                UnitMeasurementId = model.UnitMeasurement.Id
            }).ToList();

            if (entity.ProductId != ProductId)
            {
                entity.Product = null;
                entity.ProductId = ProductId;
            }

            if (entity.ClassificcationId != ClassificationId)
            {
                entity.Classification = null;
                entity.ClassificcationId = ClassificationId;
            }
        }
    }
}

