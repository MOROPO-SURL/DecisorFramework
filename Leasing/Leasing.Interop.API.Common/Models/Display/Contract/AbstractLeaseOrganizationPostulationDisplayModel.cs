namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display.Contract
{
    public abstract class AbstractLeaseOrganizationPostulationDisplayModel<TEntity> : AbstractLeasePostulationDisplayModel<TEntity> where TEntity : Persistence.Entities.Contract.AbstractLeaseOrganizationPostulation
    {
        public Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel Contact { get; set; }

        public string TaxIdentificationNumber { get; set; }

        public string StateIdentificationCode { get; set; }

        public Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel MainPostalContactItem { get; set; }

        public override void Import(TEntity entity)
        {
            base.Import(entity);

            if (entity.Contact != null)
            {
                Contact = new Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel();

                Contact.Import(entity.Contact);

                TaxIdentificationNumber = entity.Contact.TaxIdentificationNumber;
                StateIdentificationCode = entity.Contact.StateIdentificationCode;

                if (entity.Contact.MainPostalContact != null)
                {
                    MainPostalContactItem = new Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel();

                    MainPostalContactItem.Import(entity.Contact.MainPostalContact);
                }
            }
        }
    }
}
