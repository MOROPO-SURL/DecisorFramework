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

        public System.Collections.Generic.List<WarehousingDecreaseModel> WarehousingDecreases { get; set; } = new System.Collections.Generic.List<WarehousingDecreaseModel>();

        public System.Collections.Generic.List<ClassificationInputModel> Classifications { get; set; } = new System.Collections.Generic.List<ClassificationInputModel>();

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

            if (entity.CategoryId != CategoryId)
            {
                entity.Category = null;
                entity.CategoryId = CategoryId;
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
