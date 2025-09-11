using System.Collections.ObjectModel;

namespace MOROPO.Framework.Decisor.Governance.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class MeetingConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.MeetingDisplayModel>
    {
        private int index;
        private System.DateTime atDate;
        private System.TimeSpan atTime;
        private string summary;
        private string rapporteurship;
        private Interop.API.Common.Models.Display.DecisionMakingGroupDisplayModel group;
        private Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel author;

        public MeetingConfigurationPageModel(Interop.API.Common.Models.Display.MeetingDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                index = model.Index;
                summary = model.Summary;
                rapporteurship = model.Rapporteurship;
                atDate = model.At.Date;
                atTime = model.At.TimeOfDay;
                group = model.DecisionMakingGroup;
                author = model.Author;
                InternalInvitations = new ObservableCollection<Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel>(model.InternalInvitations);
                ExternalInvitations = new ObservableCollection<Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel>(model.ExternalInvitations);
                Agreements = new ObservableCollection<Interop.API.Common.Models.Display.AgreementDisplayModel>(model.Agreements);
            }
            else
            {
                var now = System.DateTime.Now;

                atDate = now.Date;
                atTime = now.TimeOfDay;
            }
        }

        public System.Guid Id { get; set; }

        public int Index { get => index; set => SetProperty(ref index, value); }

        public System.DateTime AtDate { get => atDate; set => SetProperty(ref atDate, value); }

        public System.TimeSpan AtTime { get => atTime; set => SetProperty(ref atTime, value); }

        public string Summary { get => summary; set => SetProperty(ref summary, value); }

        public string Rapporteurship { get => rapporteurship; set => SetProperty(ref rapporteurship, value); }

        public Interop.API.Common.Models.Display.DecisionMakingGroupDisplayModel Group { get => group; set => SetProperty(ref group, value); }

        public Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel Author { get => author; set => SetProperty(ref author, value); }

        public ObservableCollection<Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel> InternalInvitations { get; set; } = [];

        public ObservableCollection<Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel> ExternalInvitations { get; set; } = [];

        public ObservableCollection<Interop.API.Common.Models.Display.AgreementDisplayModel> Agreements { get; set; } = [];

        public Interop.API.Common.Models.Display.DecisionMakingGroupDisplayModel[] AvailableGroups { get; set; }
    }
}
