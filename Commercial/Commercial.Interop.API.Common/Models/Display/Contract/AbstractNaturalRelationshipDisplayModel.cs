using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Display.Contract
{
    public abstract class AbstractNaturalRelationshipDisplayModel<TEntity> : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<TEntity, System.Guid>
        where TEntity : Persistence.Entities.Contract.AbstractNaturalRelationship
    {
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public int Priority { get; set; }

        public System.DateTime At { get; set; }

        public PersonContactDisplayModel Contact { get; set; }

        public NaturalBusinessKindDisplayModel BusinessKind { get; set; }

        public Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel MainPostalContact { get; set; }

        public PaymentTermDisplayModel DefaultPaymentTerm { get; set; }

        public Financial.Interop.API.Common.Models.Display.BankAccountDisplayModel[] BankAccounts { get; set; }

        public Core.Interop.API.Common.Models.Display.DocumentDisplayModel[] Documents { get; set; }

        public virtual void Import(TEntity entity)
        {
            Id = entity.Id;
            Priority = entity.Priority;
            At = entity.At;

            if (entity.Contact != null)
            {
                Contact = new PersonContactDisplayModel();

                Contact.Import(entity.Contact);
            }

            if (entity.Contact.MainPostalContact != null)
            {
                MainPostalContact = new Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel();

                MainPostalContact.Import(entity.Contact.MainPostalContact);
            }

            if (entity.Contact.BusinessKind != null)
            {
                BusinessKind = new NaturalBusinessKindDisplayModel();

                BusinessKind.Import(entity.Contact.BusinessKind);
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

