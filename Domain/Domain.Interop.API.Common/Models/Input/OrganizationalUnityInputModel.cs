namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input
{
    public class OrganizationalUnityInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.OrganizationalUnity, System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public int Priority { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Reference { get; set; }

        public System.Guid? ParentId { get; set; }

        public Persistence.Entities.OrganizationalUnity Export()
        {
            var entity = new Persistence.Entities.OrganizationalUnity { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.OrganizationalUnity entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.OrganizationalUnity entity)
        {
            entity.Priority = Priority;
            entity.Name = Name;
            entity.Reference = Reference;

            if (entity.ParentId != ParentId)
            {
                entity.Parent = null;
                entity.ParentId = ParentId;
            }
        }
    }
}
