using MOROPO.ISCamaguey.Decisor.Production.Persistence.Entities;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Production.Interop.API.Common.Models.Input
{
    public sealed class ProductionQualityCheckInputModel : Framework.Decisor.Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<ProductionQualityCheck, System.Guid>
    {
        public System.DateTime At { get; set; }

        public System.Guid ProductionId { get; set; }

        public System.Guid AuthorId { get; set; }

        [System.ComponentModel.DataAnnotations.Range(0D, 100D)]
        public double QualityPercent { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }

        public Quality.Interop.API.Common.Models.Display.CubanStandardDisplayModel[] CubanStandards { get; set; }

        public Quality.Interop.API.Common.Models.Display.IsoStandardDisplayModel[] IsoStandards { get; set; }

        public override ProductionQualityCheck Export()
        {
            var entity = new ProductionQualityCheck { Id = Id, Archived = false };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(ProductionQualityCheck entity)
        {
            entity.At = At;
            entity.QualityPercent = QualityPercent;
            entity.Description = Description;

            entity.CubanStandardBridge.Clear();
            entity.CubanStandardBridge = CubanStandards.Select(model => new ProductionQualityCheckCubanStandardBridge { ProwId = entity.Id, SternId = model.Id }).ToList();

            entity.IsoStandardBridge.Clear();
            entity.IsoStandardBridge = IsoStandards.Select(model => new ProductionQualityCheckIsoStandardBridge { ProwId = entity.Id, SternId = model.Id }).ToList();

            if (entity.ProductionId != ProductionId)
            {
                entity.Production = null;
                entity.ProductionId = ProductionId;
            }

            if (entity.AuthorId != AuthorId)
            {
                entity.Author = null;
                entity.AuthorId = AuthorId;
            }
        }
    }
}
