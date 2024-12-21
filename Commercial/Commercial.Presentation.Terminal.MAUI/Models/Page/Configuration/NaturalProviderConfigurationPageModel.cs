namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class NaturalProviderConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.NaturalProviderDisplayModel>
    {
        private Interop.API.Common.Models.Display.PersonContactDisplayModel contact;
        private string personalIdentificationNumber;
        private int priority;

        public NaturalProviderConfigurationPageModel(Interop.API.Common.Models.Display.NaturalProviderDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Contact = model.Contact;
                PersonalIdentificationNumber = model.PersonalIdentificationNumber;
                Priority = model.Priority;
            }
        }

        public System.Guid Id { get; set; }

        public Interop.API.Common.Models.Display.PersonContactDisplayModel Contact { get => contact; set => SetProperty(ref contact, value); }

        public string PersonalIdentificationNumber { get => personalIdentificationNumber; set => SetProperty(ref personalIdentificationNumber, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }
    }
}
