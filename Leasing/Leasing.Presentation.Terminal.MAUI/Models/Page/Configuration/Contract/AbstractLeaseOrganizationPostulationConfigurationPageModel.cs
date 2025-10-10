namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration.Contract
{
    public abstract class AbstractLeaseOrganizationPostulationConfigurationPageModel<TModel, TEntity> : AbstractLeasePostulationConfigurationPageModel<TModel, TEntity>
        where TModel : Interop.API.Common.Models.Display.Contract.AbstractLeaseOrganizationPostulationDisplayModel<TEntity>
        where TEntity : Persistence.Entities.Contract.AbstractLeaseOrganizationPostulation
    {
        private Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel contact;
        private string taxIdentificationNumber;
        private string stateIdentificationCode;
        private Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel mainPostalContactItem;

        public AbstractLeaseOrganizationPostulationConfigurationPageModel(System.Guid offerId, TModel model) : base(offerId, model)
        {
            if (model != null)
            {
                contact = model.Contact;
                taxIdentificationNumber = model.TaxIdentificationNumber;
                stateIdentificationCode = model.StateIdentificationCode;
                mainPostalContactItem = model.MainPostalContactItem;
            }
        }

        public Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel Contact { get => contact; set => SetProperty(ref contact, value); }    

        public string TaxIdentificationNumber { get => taxIdentificationNumber; set => SetProperty(ref taxIdentificationNumber, value); }

        public string StateIdentificationCode { get => stateIdentificationCode; set => SetProperty(ref stateIdentificationCode, value); }

        public Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel MainPostalContactItem { get => mainPostalContactItem; set => SetProperty(ref mainPostalContactItem, value); }
    }
}
