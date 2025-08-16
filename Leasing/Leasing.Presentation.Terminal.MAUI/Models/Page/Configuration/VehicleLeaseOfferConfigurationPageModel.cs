using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class VehicleLeaseOfferConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<VehicleLeaseOfferDisplayModel>
    {
        private int priority = 1;
        private System.DateTime openAt = System.DateTime.Now;
        private System.DateTime closedAt = System.DateTime.Now;
        private bool hasClosetAtDate;
        private string description;
        private VehicleLeasePropousalDisplayModel propousal;
        private Governance.Interop.API.Common.Models.Display.AgreementDisplayModel agreement;

        public VehicleLeaseOfferConfigurationPageModel(VehicleLeaseOfferDisplayModel model) : base(model)
        {
            if (model == null) return;

            Id = model.Id;
            Priority = model.Priority;
            OpenAt = model.OpenAt;
            ClosedAt = model.ClosedAt ?? System.DateTime.Now;
            hasClosetAtDate = model.ClosedAt != null;
            Description = model.Description;
            Propousal = model.Propousal;
            Agreement = model.Agreement;
        }

        public System.Guid Id { get; set; }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public System.DateTime OpenAt { get => openAt; set => SetProperty(ref openAt, value); }

        public System.DateTime ClosedAt { get => closedAt; set => SetProperty(ref closedAt, value); }

        public bool HasClosetAtDate { get => hasClosetAtDate; set => SetProperty(ref hasClosetAtDate, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public VehicleLeasePropousalDisplayModel Propousal { get => propousal; set => SetProperty(ref propousal, value); }

        public Governance.Interop.API.Common.Models.Display.AgreementDisplayModel Agreement { get => agreement; set => SetProperty(ref agreement, value); }
    }
}
