using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Production.Persistence.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Input
{
    public class ElaborationInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Elaboration, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        public System.Guid ProductId { get; set; }

        public string Description { get; set; }

        public decimal MinPerformanceCoefficient { get; set; }

        public decimal MaxPerformanceCoefficient { get; set; }

        public List<ElaborationStepDisplayModel> Steps { get; set; } = new List<ElaborationStepDisplayModel>();

        public List<ProductDisplayModel> InputProducts { get; set; } = new List<ProductDisplayModel>();

        public List<ProductDisplayModel> OutputProducts { get; set; } = new List<ProductDisplayModel>();

        public Elaboration Export()
        {
            var entity = new Elaboration { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Elaboration entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Elaboration entity)
        {
            entity.Priority = Priority;
            entity.Description = Description;
            entity.MinPerformanceCoefficient = MinPerformanceCoefficient;
            entity.MaxPerformanceCoefficient = MaxPerformanceCoefficient;
            entity.InputProductBridges = InputProducts.Select(model => new ElaborationInputProductBridge
            {
                ProwId = entity.Id,
                SternId = model.Id
            }).ToList();
            entity.OutputProductBridges = OutputProducts.Select(model => new ElaborationOutputProductBridge
            {
                ProwId = entity.Id,
                SternId = model.Id
            }).ToList();

            if (entity.ProductId != ProductId)
            {
                entity.Product = null;
                entity.ProductId = ProductId;
            }
        }
    }
}

