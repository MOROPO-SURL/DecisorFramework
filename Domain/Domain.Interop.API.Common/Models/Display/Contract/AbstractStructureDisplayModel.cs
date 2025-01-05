using System.Linq;

namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display.Contract
{
    public abstract class AbstractStructureDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Structure, System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public StructureKindDisplayModel Kind { get; set; }

        public Core.Interop.API.Common.Models.Display.OrganizationIdentityDisplayModel Identity { get; set; }

        public OrganizationalUnityTreeDisplayModel[] OrganizationalUnities { get; set; }

        public virtual void Import(Persistence.Entities.Structure entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            OrganizationalUnities = entity.OrganizationalUnityBridges.OrderBy(bridge => bridge.Stern.Priority).Select(bridge =>
            {
                var model = new OrganizationalUnityTreeDisplayModel();

                model.Import(bridge.Stern);

                return model;
            }).ToArray();

            if (entity.Kind != null)
            {
                Kind = new StructureKindDisplayModel();

                Kind.Import(entity.Kind);
            }

            if (entity.Identity != null)
            {
                Identity = new Core.Interop.API.Common.Models.Display.OrganizationIdentityDisplayModel();

                Identity.Import(entity.Identity);
            }
        }
    }
}
