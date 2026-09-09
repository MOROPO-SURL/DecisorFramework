namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display.Contract
{
    public abstract class AbstractStructureDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.AdministrativeEntity, System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public AdministrativeEntityKindDisplayModel Kind { get; set; }

        public Core.Interop.API.Common.Models.Display.OrganizationIdentityDisplayModel Identity { get; set; }

        public OrganizationalStructureDisplayModel OrganizationalStructure { get; set; }

        public virtual void Import(Persistence.Entities.AdministrativeEntity entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Priority = entity.Priority;

            if (entity.Kind != null)
            {
                Kind = new AdministrativeEntityKindDisplayModel();

                Kind.Import(entity.Kind);
            }

            if (entity.Identity != null)
            {
                Identity = new Core.Interop.API.Common.Models.Display.OrganizationIdentityDisplayModel();

                Identity.Import(entity.Identity);
            }

            if (entity.OrganizationalStructure != null)
            {
                OrganizationalStructure = new OrganizationalStructureDisplayModel();

                OrganizationalStructure.Import(entity.OrganizationalStructure);
            }
        }
    }
}
