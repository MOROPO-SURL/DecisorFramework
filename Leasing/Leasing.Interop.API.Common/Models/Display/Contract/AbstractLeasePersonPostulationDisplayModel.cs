namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display.Contract
{
    public abstract class AbstractLeasePersonPostulationDisplayModel<TEntity> : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<TEntity, System.Guid> where TEntity : Persistence.Entities.Contract.AbstractLeasePersonPostulation
    {
        public System.Guid Id { get; set; }

        public System.Guid OfferId { get; set; }

        public Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel Contact { get; set; }

        public Domain.Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel BusinessKind { get; set; }

        public string TaxIdentificationNumber { get; set; }

        public Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel MainPostalContactItem { get; set; }

        public string Argument { get; set; }

        public virtual void Import(TEntity entity)
        {
            Id = entity.Id;
            Argument = entity.Argument;
            TaxIdentificationNumber = entity.Contact.PersonalIdentificationNumber;

            if (entity.Contact != null)
            {
                Contact = new Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel();

                Contact.Import(entity.Contact);
            }

            if (entity.Contact.BusinessKind != null)
            {
                BusinessKind = new Domain.Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel();

                BusinessKind.Import(entity.Contact.BusinessKind);
            }

            if (entity.Contact.MainPostalContact != null)
            {
                MainPostalContactItem = new Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel();

                MainPostalContactItem.Import(entity.Contact.MainPostalContact);
            }
        }
    }
}
