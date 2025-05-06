namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.Models.Page.Configuration.Bridge
{
    public class CommonLeaseOfferOrganizationContactBridgeConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.Bridge.CommonLeaseOfferOrganizationContactBridgeDisplayModel>
    {
        private Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel contact;
        private string taxIdentificationNumberLabel;
        private string stateIdentificationCode;
        private string argument;

        public CommonLeaseOfferOrganizationContactBridgeConfigurationPageModel(Interop.API.Common.Models.Display.Bridge.CommonLeaseOfferOrganizationContactBridgeDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Contact = model.Contact;
                TaxIdentificationNumberLabel = model.TaxIdentificationNumber;
                StateIdentificationCode = model.StateIdentificationCode;
                Argument = model.Argument;
            }
        }

        public Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel Contact { get => contact; set => SetProperty(ref contact, value); }

        public string TaxIdentificationNumberLabel { get => taxIdentificationNumberLabel; set => SetProperty(ref taxIdentificationNumberLabel, value); }

        public string StateIdentificationCode { get => stateIdentificationCode; set => SetProperty(ref stateIdentificationCode, value); }

        public string Argument { get => argument; set => SetProperty(ref argument, value); }
    }
}
