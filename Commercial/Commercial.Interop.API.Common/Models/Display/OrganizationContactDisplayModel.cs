namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Display
{
    public class OrganizationContactDisplayModel : Contract.AbstractContactDisplayModel<Persistence.Entities.OrganizationContact>
    {
        public Core.Interop.API.Common.Models.Display.OrganizationIdentityDisplayModel Identity { get; set; }

        public LegalBusinessKindDisplayModel BusinessKind { get; set; }

        public override void Import(Persistence.Entities.OrganizationContact entity)
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
