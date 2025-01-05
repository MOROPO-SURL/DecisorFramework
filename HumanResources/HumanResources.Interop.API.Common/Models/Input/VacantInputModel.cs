namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input
{
    public class VacantInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Vacant, System.Guid>
    {
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public int Priority { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Reference { get; set; }

        public System.Guid KindId { get; set; }

        public System.Guid SchoolingId { get; set; }

        public string Description { get; set; }

        public Persistence.Entities.Vacant Export()
        {
            var entity = new Persistence.Entities.Vacant { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Vacant entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Vacant entity)
        {
            entity.Name = Name;
            entity.Reference = Reference;
            entity.Description = Description;
            entity.Priority = Priority;

            if (entity.KindId != KindId)
            {
                entity.Kind = null;
                entity.KindId = KindId;
            }

            if (entity.SchoolingId != SchoolingId)
            {
                entity.Schooling = null;
                entity.SchoolingId = SchoolingId;
            }
        }
    }
}
