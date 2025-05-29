using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Display;
using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Input
{
    public class ProductInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Product, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public Core.Interop.API.Common.Models.Input.ImageInputModel FeatureImage { get; set; }

        public int Priority { get; set; }

        public System.Guid DefaultMetricUnityId { get; set; }

        public int? CategoryId { get; set; }

        public List<Bridge.ProductWarehousingDecreaseBridgeModel> WarehousingDecreases { get; set; } = new List<Bridge.ProductWarehousingDecreaseBridgeModel>();

        public List<ClassificationInputModel> EditionClassificationItems { get; set; } = new List<ClassificationInputModel>();
        public List<ClassificationInputModel> IncomingClassificationItems { get; set; } = new List<ClassificationInputModel>();
        public List<ClassificationDisplayModel> OutgoingClassificationItems { get; set; } = new List<ClassificationDisplayModel>();

        public Persistence.Entities.Product Export()
        {
            var entity = new Persistence.Entities.Product
            {
                Id = Id,
                Enabled = true
            };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Product entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Product entity)
        {
            entity.Name = Name;
            entity.Description = Description;
            entity.Priority = Priority;
            
            if (entity.DefaultUnitMeasurementId != DefaultMetricUnityId)
            {
                entity.UnitMeasurement = null;
                entity.DefaultUnitMeasurementId = DefaultMetricUnityId;
            }

            if (entity.FamilyId != CategoryId)
            {
                entity.Family = null;
                entity.FamilyId = CategoryId;
            }

            entity.WarehousingDecreaseKindBridges.Clear();

            foreach (var model in WarehousingDecreases)
            {
                entity.WarehousingDecreaseKindBridges.Add(new Persistence.Entities.ProductWarehousingDecreaseKindBridge
                {
                    ProductId = entity.Id,
                    Kind = model.Kind,
                    MinDecrease = model.MinDecrease,
                    MaxDecrease = model.MaxDecrease
                });
            }
        }
    }
}
