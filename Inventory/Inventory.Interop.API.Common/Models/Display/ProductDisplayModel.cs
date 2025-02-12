using System.Linq;

namespace MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Display
{
    public class ProductDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Product, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Core.Interop.API.Common.Models.Display.ImageDisplayModel FeatureImage { get; set; }

        public System.DateTime At { get; set; }

        public int Priority { get; set; }

        public UnitMeasurementDisplayModel DefaultUnitMeasurement { get; set; }

        public FamilyDisplayModel Category { get; set; }

        public ClassificationDisplayModel[] Classifications { get; set; }

        public WarehousingDecreaseModel[] WarehousingDecreases { get; set; }

        public virtual void Import(Persistence.Entities.Product entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
            At = entity.At;
            Priority = entity.Priority;
            DefaultUnitMeasurement = new UnitMeasurementDisplayModel();
            
            DefaultUnitMeasurement.Import(entity.UnitMeasurement);

            if (entity.FeatureImage != null)
            {
                FeatureImage = new Core.Interop.API.Common.Models.Display.ImageDisplayModel();

                FeatureImage.Import(entity.FeatureImage);
            }

            var warehousingDecreases = new System.Collections.Generic.List<WarehousingDecreaseModel>();

            foreach (var bridge in entity.WarehousingDecreaseKindBridges)
            {
                warehousingDecreases.Add(new WarehousingDecreaseModel
                {
                    Kind = bridge.Kind,
                    MinDecrease = bridge.MinDecrease,
                    MaxDecrease = bridge.MaxDecrease
                });
            }

            WarehousingDecreases = warehousingDecreases.ToArray();
        }
    }
}
