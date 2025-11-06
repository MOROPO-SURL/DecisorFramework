namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Display.Contract
{
    public abstract class AbstractLegalRelationshipDisplayModel<TEntity> : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<TEntity, System.Guid>
        where TEntity : Persistence.Entities.Contract.AbstractLegalRelationship
    {
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public int Priority { get; set; }

        public System.DateTime At { get; set; }

        public Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel Contact { get; set; }

        public string TaxIdentificationNumber { get; set; }

        public string StateIdentificationCode { get; set; }

        public Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel MainPostalContact { get; set; }

        public PaymentTermDisplayModel DefaultPaymentTerm { get; set; }

        public Financial.Interop.API.Common.Models.Display.BankAccountDisplayModel[] BankAccounts { get; set; }

        public Core.Interop.API.Common.Models.Display.DocumentDisplayModel[] Documents { get; set; }

        public virtual void Import(TEntity entity)
        {
            Id = entity.Id;
            Priority = entity.Priority;
            At = entity.At;
            TaxIdentificationNumber = entity.Contact.TaxIdentificationNumber;
            StateIdentificationCode = entity.Contact.StateIdentificationCode;

            if (entity.Contact != null)
            {
                Contact = new Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel();

                Contact.Import(entity.Contact);
            }

            if (entity.Contact.MainPostalContact != null)
            {
                MainPostalContact = new Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel();

                MainPostalContact.Import(entity.Contact.MainPostalContact);
            }

            if (entity.DefaultPaymentTerm != null)
            {
                DefaultPaymentTerm = new PaymentTermDisplayModel();

                DefaultPaymentTerm.Import(entity.DefaultPaymentTerm);
            }
        }

        public override string ToString()
        {
            return Contact?.ToString();
        }
    }
}

