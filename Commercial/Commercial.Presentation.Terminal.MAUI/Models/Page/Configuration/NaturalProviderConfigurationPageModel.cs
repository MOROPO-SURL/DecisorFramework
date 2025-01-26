using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class NaturalProviderConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.NaturalProviderDisplayModel>
    {
        private PersonContactDisplayModel contact;
        private int priority;

        public NaturalProviderConfigurationPageModel(Interop.API.Common.Models.Display.NaturalProviderDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Contact = model.Contact;
                Priority = model.Priority;
            }
        }

        public System.Guid Id { get; set; }

        public PersonContactDisplayModel Contact { get => contact; set => SetProperty(ref contact, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }
    }
}
