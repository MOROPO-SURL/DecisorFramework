namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display.Contract
{
    public abstract class AbstractLeasePersonPostulationDisplayModel<TEntity> : AbstractLeasePostulationDisplayModel<TEntity> where TEntity : Persistence.Entities.Contract.AbstractLeasePersonPostulation
    {
        public Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel Contact { get; set; }

        public Domain.Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel BusinessKind { get; set; }

        public string TaxIdentificationNumber { get; set; }

        public Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel MainPostalContactItem { get; set; }

        public override void Import(TEntity entity)
        {
            base.Import(entity);

            if (entity.Contact != null)
            {
                Contact = new Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel();

                Contact.Import(entity.Contact);

                TaxIdentificationNumber = entity.Contact.PersonalIdentificationNumber;
                
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
}
