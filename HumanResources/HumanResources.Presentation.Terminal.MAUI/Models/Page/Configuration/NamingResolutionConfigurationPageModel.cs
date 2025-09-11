namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class NamingResolutionConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.NamingResolutionDisplayModel>
    {
        private int index;
        private System.DateTime at = System.DateTime.Now;
        private string summary;
        private Governance.Interop.API.Common.Models.Display.AgreementDisplayModel agreement;
        private Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel contact;
        private Interop.API.Common.Models.Display.VacantDisplayModel vacant;
        private Interop.API.Common.Models.Display.StaffDisplayModel staff;
        private Interop.API.Common.Models.Display.OcupationCandidateDisplayModel candidate;

        public NamingResolutionConfigurationPageModel(Interop.API.Common.Models.Display.NamingResolutionDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                index = model.Index;
                at = model.At;
                summary = model.Summary;
                agreement = model.Agreement;
                contact = model.Contact;
                staff = model.Staff;
                vacant = model.Vacant;
                candidate = model.Candidate;
            }
        }

        public System.Guid Id { get; set; }

        public bool IsForOcupationCandidate { get; set; }

        public int Index { get => index; set => SetProperty(ref index, value); }

        public System.DateTime At { get => at; set => SetProperty(ref at, value); }

        public string Summary { get => summary; set => SetProperty(ref summary, value); }

        public Governance.Interop.API.Common.Models.Display.AgreementDisplayModel Agreement { get => agreement; set => SetProperty(ref agreement, value); }

        public Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel Contact { get => contact; set => SetProperty(ref contact, value); }

        public Interop.API.Common.Models.Display.VacantDisplayModel Vacant { get => vacant; set => SetProperty(ref vacant, value); }

        public Interop.API.Common.Models.Display.StaffDisplayModel Staff { get => staff; set => SetProperty(ref staff, value); }

        public Interop.API.Common.Models.Display.OcupationCandidateDisplayModel Candidate { get => candidate; set => SetProperty(ref candidate, value); }
    }
}
