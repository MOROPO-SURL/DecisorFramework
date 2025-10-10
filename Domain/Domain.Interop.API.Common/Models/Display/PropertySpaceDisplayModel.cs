namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display
{
    public class PropertySpaceDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.PropertySpace, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public bool Enabled { get; set; }

        public Persistence.Enumerations.PropertyAssignment? Assignment { get; set; }

        public Core.Interop.API.Common.Models.Display.ImageDisplayModel FeatureImage { get; set; }

        public decimal Area { get; set; }

        public string Description { get; set; }

        public void Import(Persistence.Entities.PropertySpace entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Enabled = entity.Enabled;
            Assignment = entity.Assignment;
            Area = entity.Area;
            Description = entity.Description;

            if (entity.FeatureImage != null)
            {
                FeatureImage = new Core.Interop.API.Common.Models.Display.ImageDisplayModel();

                FeatureImage.Import(entity.FeatureImage);
            }
        }
    }
}
