namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration.Contract
{
    public abstract class AbstractLeasePersonPostulationConfigurationPageModel<TModel, TEntity> : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<TModel>
        where TModel : Interop.API.Common.Models.Display.Contract.AbstractLeasePersonPostulationDisplayModel<TEntity>
        where TEntity : Persistence.Entities.Contract.AbstractLeasePersonPostulation
    {
        private Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel contact;
        private string taxIdentificationNumber;
        private Domain.Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel businessKind;
        private string argument;

        public AbstractLeasePersonPostulationConfigurationPageModel(System.Guid offerId, TModel model) : base(model)
        {
            OfferId = offerId;

            if (model != null)
            {
                Id = model.Id;
                Contact = model.Contact;
                TaxIdentificationNumber = model.TaxIdentificationNumber;
                BusinessKind = model.BusinessKind;
                Argument = model.Argument;
            }
        }

        public System.Guid Id { get; set; }

        public System.Guid OfferId { get; set; }

        public Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel Contact { get => contact; set => SetProperty(ref contact, value); }

        public string TaxIdentificationNumber { get => taxIdentificationNumber; set => SetProperty(ref taxIdentificationNumber, value); }

        public Domain.Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel BusinessKind { get => businessKind; set => SetProperty(ref businessKind, value); }

        public string Argument { get => argument; set => SetProperty(ref argument, value); }

        public Domain.Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel[] AvailableBusinessKinds { get; set; }
    }
}
