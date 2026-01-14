namespace MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display
{
    public class ElaborationDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Elaboration, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; }

        public string Name { get; set; }

        public Inventory.Interop.API.Common.Models.Display.ProductDisplayModel Product { get; set; }

        public Inventory.Interop.API.Common.Models.Display.ClassificationDisplayModel Classification { get; set; }

        public string Description { get; set; }

        public decimal MinPerformanceCoefficient { get; set; }

        public decimal MaxPerformanceCoefficient { get; set; }

        public Bridge.CommonElaborationProductBridgeModel[] InputProductBridges { get; set; }

        public Bridge.CommonElaborationProductBridgeModel[] OutputProductBridges { get; set; }

        public Core.Interop.API.Common.Models.Display.DocumentDisplayModel[] Documents { get; set; }

        public ElaborationStepDisplayModel[] Steps { get; set; }

        public virtual void Import(Persistence.Entities.Elaboration entity)
        {
            Id = entity.Id;
            Priority = entity.Priority;
            At = entity.At;
            Name = entity.Name;
            Description = entity.Description;
            MinPerformanceCoefficient = entity.MinPerformanceCoefficient;
            MaxPerformanceCoefficient = entity.MaxPerformanceCoefficient;

            if (entity.Product != null)
            {
                Product = new Inventory.Interop.API.Common.Models.Display.ProductDisplayModel();

                Product.Import(entity.Product);
            }

            if (entity.Classification != null)
            {
                Classification = new Inventory.Interop.API.Common.Models.Display.ClassificationDisplayModel();

                Classification.Import(entity.Classification);
            }

            var inputProductBridges = new System.Collections.Generic.List<Bridge.CommonElaborationProductBridgeModel>();

            foreach (var bridge in entity.InputProductBridges)
            {
                var model = new Bridge.CommonElaborationProductBridgeModel
                {
                    Product = new Inventory.Interop.API.Common.Models.Display.ProductDisplayModel(),
                    Amount = bridge.Amount,
                    UnitMeasurement = new Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel()
                };

                model.Product.Import(bridge.Stern);
                model.UnitMeasurement.Import(bridge.UnitMeasurement);

                inputProductBridges.Add(model);
            }

            foreach (var bridge in entity.InputProductClassificationBridges)
            {
                var model = new Bridge.CommonElaborationProductBridgeModel
                {
                    Product = new Inventory.Interop.API.Common.Models.Display.ProductDisplayModel(),
                    Classification = new Inventory.Interop.API.Common.Models.Display.ClassificationDisplayModel(),
                    Amount = bridge.Amount,
                    UnitMeasurement = new Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel()
                };

                model.Product.Import(bridge.Stern.Product);
                model.Classification.Import(bridge.Stern);
                model.UnitMeasurement.Import(bridge.UnitMeasurement);

                inputProductBridges.Add(model);
            }

            var outputProductBridges = new System.Collections.Generic.List<Bridge.CommonElaborationProductBridgeModel>();

            foreach (var bridge in entity.OutputProductBridges)
            {
                var model = new Bridge.CommonElaborationProductBridgeModel
                {
                    Product = new Inventory.Interop.API.Common.Models.Display.ProductDisplayModel(),
                    Amount = bridge.Amount,
                    UnitMeasurement = new Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel()
                };

                model.Product.Import(bridge.Stern);
                model.UnitMeasurement.Import(bridge.UnitMeasurement);

                outputProductBridges.Add(model);
            }

            foreach (var bridge in entity.OutputProductClassificationBridges)
            {
                var model = new Bridge.CommonElaborationProductBridgeModel
                {
                    Product = new Inventory.Interop.API.Common.Models.Display.ProductDisplayModel(),
                    Classification = new Inventory.Interop.API.Common.Models.Display.ClassificationDisplayModel(),
                    Amount = bridge.Amount,
                    UnitMeasurement = new Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel()
                };

                model.Product.Import(bridge.Stern.Product);
                model.Classification.Import(bridge.Stern);
                model.UnitMeasurement.Import(bridge.UnitMeasurement);

                outputProductBridges.Add(model);
            }

            InputProductBridges = inputProductBridges.ToArray();
            OutputProductBridges = outputProductBridges.ToArray();
        }
    }
}

