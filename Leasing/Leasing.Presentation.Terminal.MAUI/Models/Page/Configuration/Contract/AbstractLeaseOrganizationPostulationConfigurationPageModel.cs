using System.Collections.ObjectModel;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration.Contract
{
    public abstract class AbstractLeaseOrganizationPostulationConfigurationPageModel<TModel, TEntity> : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<TModel>
        where TModel : Interop.API.Common.Models.Display.Contract.AbstractLeaseOrganizationPostulationDisplayModel<TEntity>
        where TEntity : Persistence.Entities.Contract.AbstractLeaseOrganizationPostulation
    {
        private Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel contact;
        private string taxIdentificationNumber;
        private string stateIdentificationCode;
        private Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel mainPostalContactItem;
        private string argument;

        public AbstractLeaseOrganizationPostulationConfigurationPageModel(System.Guid offerId, TModel model) : base(model)
        {
            OfferId = offerId;

            if (model != null)
            {
                Id = model.Id;
                contact = model.Contact;
                taxIdentificationNumber = model.TaxIdentificationNumber;
                stateIdentificationCode = model.StateIdentificationCode;
                mainPostalContactItem = model.MainPostalContactItem;
                argument = model.Argument;
                Documents = new ObservableCollection<Core.Interop.API.Common.Models.Display.DocumentDisplayModel>(model.Documents);
            }
        }

        public System.Guid Id { get; set; }

        public System.Guid OfferId { get; set; }

        public Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel Contact { get => contact; set => SetProperty(ref contact, value); }

        public string TaxIdentificationNumber { get => taxIdentificationNumber; set => SetProperty(ref taxIdentificationNumber, value); }

        public string StateIdentificationCode { get => stateIdentificationCode; set => SetProperty(ref stateIdentificationCode, value); }

        public Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel MainPostalContactItem { get => mainPostalContactItem; set => SetProperty(ref mainPostalContactItem, value); }

        public string Argument { get => argument; set => SetProperty(ref argument, value); }

        public ObservableCollection<Core.Interop.API.Common.Models.Display.DocumentDisplayModel> Documents { get; set; } = [];
    }
}
