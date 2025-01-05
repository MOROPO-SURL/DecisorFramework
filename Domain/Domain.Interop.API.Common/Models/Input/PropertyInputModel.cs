namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input
{
    public class PropertyInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Property, System.Guid>
    {
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public int Priority { get; set; }

        public System.Guid KindId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public Core.Interop.API.Common.Models.Input.PostalContactInputModel PostalContact { get; set; }

        public Core.Interop.API.Common.Models.Input.ImageInputModel FeatureImage { get; set; }

        public System.Guid StructureId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string PropertyRecordIdentifier { get; set; }

        public decimal Area { get; set; }

        public string Description { get; set; }

        public Persistence.Entities.Property Export()
        {
            var entity = new Persistence.Entities.Property { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Property entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Property entity)
        {
            entity.Priority = Priority;
            entity.PropertyRecordIdentifier = PropertyRecordIdentifier;
            entity.Area = Area;
            entity.Description = Description;

            if (entity.KindId != KindId)
            {
                entity.Kind = null;
                entity.KindId = KindId;
            }

            if (entity.StructureId != StructureId)
            {
                entity.Structure = null;
                entity.StructureId = StructureId;
            }
        }
    }
}
