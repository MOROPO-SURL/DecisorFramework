namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display.Contract
{
    public abstract class AbstractOrganizationalUnityDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.OrganizationalUnity, System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public string Name { get; set; }

        public string Reference { get; set; }

        public virtual void Import(Persistence.Entities.OrganizationalUnity entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            Name = entity.Name;
            Reference = entity.Reference;
        }
    }
}
