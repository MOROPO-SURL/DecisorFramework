using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input
{
    public class PropertyInputModel : Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<Persistence.Entities.Property, System.Guid>
    {
        public int Priority { get; set; }

        public System.Guid KindId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public PostalContactItemInputModel PostalContact { get; set; }

        public ImageInputModel FeatureImage { get; set; }

        public System.Guid StructureId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Reference { get; set; }

        public string Description { get; set; }

        public List<ImageInputModel> IncomingImageItems { get; set; } = new List<ImageInputModel>();
        public List<ImageDisplayModel> OutgoingImagetItems { get; set; } = new List<ImageDisplayModel>();

        public List<PropertySpaceInputModel> EditionSpaces { get; set; } = new List<PropertySpaceInputModel>();
        public List<PropertySpaceInputModel> IncomingSpaces { get; set; } = new List<PropertySpaceInputModel>();
        public List<Display.PropertySpaceDisplayModel> OutgoingSpaces { get; set; } = new List<Display.PropertySpaceDisplayModel>();

        public override Persistence.Entities.Property Export()
        {
            var entity = new Persistence.Entities.Property { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.Property entity)
        {
            entity.Priority = Priority;
            entity.Name = Name;
            entity.Reference = Reference;
            entity.Description = Description;

            if (entity.KindId != KindId)
            {
                entity.Kind = null;
                entity.KindId = KindId;
            }

            if (entity.AdministrativeEntityId != StructureId)
            {
                entity.AdministrativeEntity = null;
                entity.AdministrativeEntityId = StructureId;
            }
        }
    }
}
