namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class NamingResolutionConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.NamingResolutionDisplayModel>
    {
        private long id;
        private System.DateTime at = System.DateTime.Now;
        private string summary;
        private Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel contact;
        private Governance.Interop.API.Common.Models.Display.AgreementDisplayModel agreement;
        private Interop.API.Common.Models.Display.VacantDisplayModel vacant;
        private Interop.API.Common.Models.Display.StaffDisplayModel staff;

        public NamingResolutionConfigurationPageModel(Interop.API.Common.Models.Display.NamingResolutionDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                at = model.At;
                summary = model.Summary;
                contact = model.Contact;
                agreement = model.Agreement;
                staff = model.Staff;
                vacant = model.Vacant;
            }
        }

        public long Id { get => id; set => SetProperty(ref id, value); }

        public Interop.API.Common.Models.Display.StaffDisplayModel Staff { get => staff; set => SetProperty(ref staff, value); }

        public System.DateTime At { get => at; set => SetProperty(ref at, value); }

        public string Summary { get => summary; set => SetProperty(ref summary, value); }

        public Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel Contact { get => contact; set => SetProperty(ref contact, value); }

        public Governance.Interop.API.Common.Models.Display.AgreementDisplayModel Agreement { get => agreement; set => SetProperty(ref agreement, value); }

        public Interop.API.Common.Models.Display.VacantDisplayModel Vacant { get => vacant; set => SetProperty(ref vacant, value); }
    }
}
