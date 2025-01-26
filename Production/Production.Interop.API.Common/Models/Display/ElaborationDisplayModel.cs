using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Display;
using System.Linq;

namespace MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display
{
    public class ElaborationDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Elaboration, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; }

        public ProductDisplayModel Product { get; set; }

        public string Description { get; set; }

        public decimal MinPerformanceCoefficient { get; set; }

        public decimal MaxPerformanceCoefficient { get; set; }

        public ProductDisplayModel[] InputProducts { get; set; }

        public ProductDisplayModel[] OutputProducts { get; set; }

        public ElaborationStepDisplayModel[] Steps { get; set; }

        public virtual void Import(Persistence.Entities.Elaboration entity)
        {
            Id = entity.Id;
            Priority = entity.Priority;
            At = entity.At;
            Description = entity.Description;
            MinPerformanceCoefficient = entity.MinPerformanceCoefficient;
            MaxPerformanceCoefficient = entity.MaxPerformanceCoefficient;
            InputProducts = entity.InputProductBridges.Select(bridge =>
            {
                var model = new ProductDisplayModel();

                model.Import(bridge.Stern);

                return model;
            }).ToArray();
            OutputProducts = entity.OutputProductBridges.Select(bridge =>
            {
                var model = new ProductDisplayModel();

                model.Import(bridge.Stern);

                return model;
            }).ToArray();

            if (entity.Product != null)
            {
                Product = new ProductDisplayModel();

                Product.Import(entity.Product);
            }
        }
    }
}

