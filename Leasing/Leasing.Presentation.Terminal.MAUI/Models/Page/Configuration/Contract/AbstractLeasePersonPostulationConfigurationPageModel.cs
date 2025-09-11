namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration.Contract
{
    public abstract class AbstractLeasePersonPostulationConfigurationPageModel<TModel, TEntity> : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<TModel>
        where TModel : Interop.API.Common.Models.Display.Contract.AbstractLeasePersonPostulationDisplayModel<TEntity>
        where TEntity : Persistence.Entities.Contract.AbstractLeasePersonPostulation
    {
        private Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel contact;
        private string taxIdentificationNumber;
        private Domain.Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel businessKind;
        private Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel mainPostalContactItem;
        private string argument;

        public AbstractLeasePersonPostulationConfigurationPageModel(System.Guid offerId, TModel model) : base(model)
        {
            OfferId = offerId;

            if (model != null)
            {
                Id = model.Id;
                contact = model.Contact;
                taxIdentificationNumber = model.TaxIdentificationNumber;
                businessKind = model.BusinessKind;
                mainPostalContactItem = model.MainPostalContactItem;
                argument = model.Argument;
            }
        }

        public System.Guid Id { get; set; }

        public System.Guid OfferId { get; set; }

        public Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel Contact { get => contact; set => SetProperty(ref contact, value); }

        public string TaxIdentificationNumber { get => taxIdentificationNumber; set => SetProperty(ref taxIdentificationNumber, value); }

        public Domain.Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel BusinessKind { get => businessKind; set => SetProperty(ref businessKind, value); }

        public Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel MainPostalContactItem { get => mainPostalContactItem; set => SetProperty(ref mainPostalContactItem, value); }

        public string Argument { get => argument; set => SetProperty(ref argument, value); }

        public Domain.Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel[] AvailableBusinessKinds { get; set; }
    }
}
