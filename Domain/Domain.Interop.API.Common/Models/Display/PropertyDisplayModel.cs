namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display
{
    public class PropertyDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Property, System.Guid>
    {
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public int Priority { get; set; }

        public string Name { get; set; }

        public PropertyKindDisplayModel Kind { get; set; }

        public Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel PostalContact { get; set; }

        public Core.Interop.API.Common.Models.Display.ImageDisplayModel FeatureImage { get; set; }

        public StructureParentalDisplayModel Structure { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Reference { get; set; }

        public string Description { get; set; }

        public Core.Interop.API.Common.Models.Display.ImageDisplayModel[] Images { get; set; }

        public PropertySpaceDisplayModel[] Spaces { get; set; }

        public void Import(Persistence.Entities.Property entity)
        {
            Id = entity.Id;
            Priority = entity.Priority;
            Name = entity.Name;
            Reference = entity.Reference;
            Description = entity.Description;

            if (entity.Kind != null)
            {
                Kind = new PropertyKindDisplayModel();

                Kind.Import(entity.Kind);
            }

            if (entity.PostalContact != null)
            {
                PostalContact = new Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel();

                PostalContact.Import(entity.PostalContact);
            }

            if (entity.FeatureImage != null)
            {
                FeatureImage = new Core.Interop.API.Common.Models.Display.ImageDisplayModel();

                FeatureImage.Import(entity.FeatureImage);
            }

            if (entity.Structure != null)
            {
                Structure = new StructureParentalDisplayModel();

                Structure.Import(entity.Structure);
            }
        }
    }
}
