namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration.Contract
{
    public abstract class AbstractLeasePersonPostulationConfigurationPageModel<TModel, TEntity> : AbstractLeasePostulationConfigurationPageModel<TModel, TEntity>
        where TModel : Interop.API.Common.Models.Display.Contract.AbstractLeasePersonPostulationDisplayModel<TEntity>
        where TEntity : Persistence.Entities.Contract.AbstractLeasePersonPostulation
    {
        private Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel contact;
        private string taxIdentificationNumber;
        private Domain.Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel businessKind;
        private Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel mainPostalContactItem;

        public AbstractLeasePersonPostulationConfigurationPageModel(System.Guid offerId, TModel model) : base(offerId, model)
        {
            if (model != null)
            {
                contact = model.Contact;
                taxIdentificationNumber = model.TaxIdentificationNumber;
                businessKind = model.BusinessKind;
                mainPostalContactItem = model.MainPostalContactItem;
            }
        }

        public Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel Contact { get => contact; set => SetProperty(ref contact, value); }

        public string TaxIdentificationNumber { get => taxIdentificationNumber; set => SetProperty(ref taxIdentificationNumber, value); }

        public Domain.Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel BusinessKind { get => businessKind; set => SetProperty(ref businessKind, value); }

        public Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel MainPostalContactItem { get => mainPostalContactItem; set => SetProperty(ref mainPostalContactItem, value); }

        public Domain.Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel[] AvailableBusinessKinds { get; set; }
    }
}
