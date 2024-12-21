namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class LegalProviderConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.LegalProviderDisplayModel>
    {
        private Interop.API.Common.Models.Display.OrganizationContactDisplayModel contact;
        private string taxIdentificationNumber;
        private int priority;

        public LegalProviderConfigurationPageModel(Interop.API.Common.Models.Display.LegalProviderDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Contact = model.Contact;
                TaxIdentificationNumber = model.TaxIdentificationNumber;
                Priority = model.Priority;
            }
        }

        public System.Guid Id { get; set; }

        public Interop.API.Common.Models.Display.OrganizationContactDisplayModel Contact { get => contact; set => SetProperty(ref contact, value); }

        public string TaxIdentificationNumber { get => taxIdentificationNumber; set => SetProperty(ref taxIdentificationNumber, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }
    }
}
