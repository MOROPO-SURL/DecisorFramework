using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class CommonLeaseOrganizationPostulationConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<CommonLeaseOrganizationPostulationDisplayModel>
    {
        private Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel contact;
        private string taxIdentificationNumber;
        private string stateIdentificationCode;
        private string argument;

        public CommonLeaseOrganizationPostulationConfigurationPageModel(CommonLeaseOrganizationPostulationDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Contact = model.Contact;
                TaxIdentificationNumber = model.TaxIdentificationNumber;
                StateIdentificationCode = model.StateIdentificationCode;
                Argument = model.Argument;
            }
        }

        public Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel Contact { get => contact; set => SetProperty(ref contact, value); }

        public string TaxIdentificationNumber { get => taxIdentificationNumber; set => SetProperty(ref taxIdentificationNumber, value); }

        public string StateIdentificationCode { get => stateIdentificationCode; set => SetProperty(ref stateIdentificationCode, value); }

        public string Argument { get => argument; set => SetProperty(ref argument, value); }
    }
}
