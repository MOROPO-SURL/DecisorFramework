namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display
{
    public class OrganizationContactDisplayModel : Contract.AbstractContactDisplayModel<Persistence.Entities.OrganizationContact>
    {
        public Core.Interop.API.Common.Models.Display.OrganizationIdentityDisplayModel Identity { get; set; }

        public PersonContactDisplayModel Representative { get; set; }

        public string TaxIdentificationNumber { get; set; }

        public string StateIdentificationCode { get; set; }

        public CentralStateStructureDisplayModel CentralStateStructure { get; set; }

        public Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel MainPostalContactItem { get; set; }

        public LegalBusinessKindDisplayModel BusinessKind { get; set; }

        public override void Import(Persistence.Entities.OrganizationContact entity)
        {
            base.Import(entity);

            TaxIdentificationNumber = entity.TaxIdentificationNumber;
            StateIdentificationCode = entity.StateIdentificationCode;

            if (entity.Identity != null)
            {
                Identity = new Core.Interop.API.Common.Models.Display.OrganizationIdentityDisplayModel();

                Identity.Import(entity.Identity);
            }

            if (entity.CentralStateStructure != null)
            {
                CentralStateStructure = new CentralStateStructureDisplayModel();

                CentralStateStructure.Import(entity.CentralStateStructure);
            }

            if (entity.Representative != null) 
            {
                Representative = new PersonContactDisplayModel();

                Representative.Import(entity.Representative);
            }

            if (entity.BusinessKind != null)
            {
                BusinessKind = new LegalBusinessKindDisplayModel();

                BusinessKind.Import(entity.BusinessKind);
            }

            if (entity.MainPostalContact != null)
            {
                MainPostalContactItem = new Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel();

                MainPostalContactItem.Import(entity.MainPostalContact);
            }
        }

        public override string ToString()
        {
            return Identity?.ToString();
        }
    }
}
