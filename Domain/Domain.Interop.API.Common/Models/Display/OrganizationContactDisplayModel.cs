using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display.Contract;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display
{
    public class OrganizationContactDisplayModel : AbstractContactDisplayModel<OrganizationContact>
    {
        public Core.Interop.API.Common.Models.Display.OrganizationIdentityDisplayModel Identity { get; set; }

        public LegalBusinessKindDisplayModel BusinessKind { get; set; }

        public override void Import(OrganizationContact entity)
        {
            base.Import(entity);

            if (entity.Identity != null)
            {
                Identity = new Core.Interop.API.Common.Models.Display.OrganizationIdentityDisplayModel();

                Identity.Import(entity.Identity);
            }

            if (entity.BusinessKind != null)
            {
                BusinessKind = new LegalBusinessKindDisplayModel();

                BusinessKind.Import(entity.BusinessKind);
            }
        }

        public override string ToString()
        {
            return Identity?.ToString();
        }
    }
}
