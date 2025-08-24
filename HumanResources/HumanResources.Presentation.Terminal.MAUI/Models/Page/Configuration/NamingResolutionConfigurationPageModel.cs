namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class NamingResolutionConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.NamingResolutionDisplayModel>
    {
        private long id;
        private System.DateTime at = System.DateTime.Now;
        private string summary;
        private Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel contact;

        public NamingResolutionConfigurationPageModel(Interop.API.Common.Models.Display.NamingResolutionDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                At = model.At;
                Summary = model.Summary;
                Contact = model.Contact;
            }
        }

        public long Id { get => id; set => SetProperty(ref id, value); }

        public System.DateTime At { get => at; set => SetProperty(ref at, value); }

        public string Summary { get => summary; set => SetProperty(ref summary, value); }

        public Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel Contact { get => contact; set => SetProperty(ref contact, value); }
    }
}
