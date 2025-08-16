namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration.Contract
{
    public abstract class AbstractLeaseOrganizationPostulationConfigurationPageModel<TModel, TEntity> : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<TModel>
        where TModel : Interop.API.Common.Models.Display.Contract.AbstractLeaseOrganizationPostulationDisplayModel<TEntity>
        where TEntity : Persistence.Entities.Contract.AbstractLeaseOrganizationPostulation
    {
        private Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel contact;
        private string taxIdentificationNumber;
        private string stateIdentificationCode;
        private string argument;

        public AbstractLeaseOrganizationPostulationConfigurationPageModel(System.Guid offerId, TModel model) : base(model)
        {
            OfferId = offerId;

            if (model != null)
            {
                Id = model.Id;
                Contact = model.Contact;
                TaxIdentificationNumber = model.TaxIdentificationNumber;
                StateIdentificationCode = model.StateIdentificationCode;
                Argument = model.Argument;
            }
        }

        public System.Guid Id { get; set; }

        public System.Guid OfferId { get; set; }

        public Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel Contact { get => contact; set => SetProperty(ref contact, value); }

        public string TaxIdentificationNumber { get => taxIdentificationNumber; set => SetProperty(ref taxIdentificationNumber, value); }

        public string StateIdentificationCode { get => stateIdentificationCode; set => SetProperty(ref stateIdentificationCode, value); }

        public string Argument { get => argument; set => SetProperty(ref argument, value); }
    }
}
