using CommunityToolkit.Maui.Core.Extensions;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class VehicleLeaseOfferConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<VehicleLeaseOfferDisplayModel>
    {
        private int priority = 1;
        private System.DateTime? openAt;
        private System.DateTime? closedAt;
        private string description;
        private Domain.Interop.API.Common.Models.Display.VehicleDisplayModel vehicle;

        public VehicleLeaseOfferConfigurationPageModel(VehicleLeaseOfferDisplayModel model) : base(model)
        {
            if (model == null) return;

            Priority = model.Priority;
            OpenAt = model.OpenAt;
            ClosedAt = model.ClosedAt;
            Description = model.Description;
            Vehicle = model.Vehicle;
            OrganizationPostulations = model.OrganizationPostulations.ToObservableCollection();
            PersonPostulations = model.PersonPostulations.ToObservableCollection();
        }

        public System.Guid Id { get; set; }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public System.DateTime? OpenAt { get => openAt; set => SetProperty(ref openAt, value); }

        public System.DateTime? ClosedAt { get => closedAt; set => SetProperty(ref closedAt, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public Domain.Interop.API.Common.Models.Display.VehicleDisplayModel Vehicle { get => vehicle; set => SetProperty(ref vehicle, value); }

        public System.Collections.ObjectModel.ObservableCollection<CommonLeaseOrganizationPostulationDisplayModel> OrganizationPostulations { get; set; } = [];

        public System.Collections.ObjectModel.ObservableCollection<CommonLeasePersonPostulationDisplayModel> PersonPostulations { get; set; } = [];
    }
}
