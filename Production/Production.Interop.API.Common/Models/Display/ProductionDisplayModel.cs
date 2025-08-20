using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Bridge;
using System.Linq;

namespace MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display
{
    public class ProductionDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Production, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; }

        public ProductionOrderDisplayModel Plan { get; set; }

        public decimal Amount { get; set; }

        public UnitMeasurementDisplayModel UnitMeasurement { get; set; }

        public string Description { get; set; }

        public ProductionProductBridgeModel[] ProductBridges { get; set; }

        public ProductionEmployeeBridgeModel[] EmployeeBridges { get; set; }

        public ProductionColaboratorBridgeModel[] ColaboratorBridges { get; set; }

        public virtual void Import(Persistence.Entities.Production entity)
        {
            Id = entity.Id;
            Priority = entity.Priority;
            At = entity.At;
            Amount = entity.Amount;
            Description = entity.Description;
            ProductBridges = entity.ProductBridges.Select(bridge =>
            {
                var model = new ProductionProductBridgeModel
                {
                    Product = new ProductDisplayModel(),
                    Amount = bridge.Amount,
                    UnitMeasurement = new UnitMeasurementDisplayModel()
                };

                model.Product.Import(bridge.Stern);
                model.UnitMeasurement.Import(bridge.UnitMeasurement);

                return model;
            }).ToArray();
            EmployeeBridges = entity.EmployeeBridges.Select(bridge =>
            {
                var model = new ProductionEmployeeBridgeModel
                {
                    Employee = new Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel(),
                    WorkPosition = new HumanResources.Interop.API.Common.Models.Display.WorkPositionDisplayModel(),
                    Step = new ElaborationStepDisplayModel()
                };

                model.Employee.Import(bridge.Stern);
                model.Step.Import(bridge.Step);
                model.WorkPosition.Import(bridge.WorkPosition);

                return model;
            }).ToArray();
            ColaboratorBridges = entity.ColaboratorBridges.Select(bridge =>
            {
                var model = new ProductionColaboratorBridgeModel
                {
                    Colaborator = new Essential.Interop.API.Common.Models.Display.ColaboratorDisplayModel(),
                    WorkPosition = new HumanResources.Interop.API.Common.Models.Display.WorkPositionDisplayModel(),
                    Step = new ElaborationStepDisplayModel()
                };

                model.Colaborator.Import(bridge.Stern);
                model.Step.Import(bridge.Step);
                model.WorkPosition.Import(bridge.WorkPosition);

                return model;
            }).ToArray();

            if (entity.Plan != null)
            {
                Plan = new ProductionOrderDisplayModel();

                Plan.Import(entity.Plan);
            }

            if (entity.UnitMeasurement != null)
            {
                UnitMeasurement = new UnitMeasurementDisplayModel();

                UnitMeasurement.Import(entity.UnitMeasurement);
            }
        }
    }
}

