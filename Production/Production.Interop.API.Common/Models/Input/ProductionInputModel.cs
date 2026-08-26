using System.Linq;

namespace MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Input
{
    public class ProductionInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Production, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        public System.Guid OrderId { get; set; }

        public decimal Amount { get; set; }

        public System.Guid UnitMeasurementId { get; set; }

        public string Description { get; set; }

        public System.Collections.Generic.List<Bridge.ProductionProductBridgeModel> ProductBridges { get; set; } = new System.Collections.Generic.List<Bridge.ProductionProductBridgeModel>();

        public System.Collections.Generic.List<Bridge.ProductionEmployeeBridgeModel> EmployeeBridges { get; set; } = new System.Collections.Generic.List<Bridge.ProductionEmployeeBridgeModel>();

        public System.Collections.Generic.List<Bridge.ProductionColaboratorBridgeModel> ColaboratorBridges { get; set; } = new System.Collections.Generic.List<Bridge.ProductionColaboratorBridgeModel>();

        public Persistence.Entities.Production Export()
        {
            var entity = new Persistence.Entities.Production { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Production entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Production entity)
        {
            entity.Priority = Priority;
            entity.Amount = Amount;
            entity.Description = Description;

            if (entity.OrderId != OrderId)
            {
                entity.Order = null;
                entity.OrderId = OrderId;
            }

            if (entity.UnitMeasurementId != UnitMeasurementId)
            {
                entity.UnitMeasurement = null;
                entity.UnitMeasurementId = UnitMeasurementId;
            }

            entity.ProductBridges = ProductBridges.Select(model => new Persistence.Entities.ProductionProductBridge
            {
                ProwId = entity.Id,
                SternId = model.Product.Id,
                Amount = model.Amount,
                UnitMeasurementId = model.UnitMeasurement.Id,
            }).ToList();

            entity.EmployeeBridges = EmployeeBridges.Select(model => new Persistence.Entities.ProductionEmployeeBridge
            {
                ProwId = entity.Id,
                SternId = model.Employee.Id,
                StepId = model.Step.Id,
                WorkPositionId = model.WorkPosition.Id,
            }).ToList();

            entity.ColaboratorBridges = ColaboratorBridges.Select(model => new Persistence.Entities.ProductionColaboratorBridge
            {
                ProwId = entity.Id,
                SternId = model.Colaborator.Id,
                StepId = model.Step.Id,
                WorkPositionId = model.WorkPosition.Id,
            }).ToList();
        }
    }
}

