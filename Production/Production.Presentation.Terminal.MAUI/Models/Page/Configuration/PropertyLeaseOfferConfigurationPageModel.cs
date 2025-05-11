using CommunityToolkit.Maui.Core.Extensions;
using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class PropertyLeaseOfferConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<PropertyLeaseOfferDisplayModel>
    {
        private int priority;
        private System.DateTime openAt;
        private System.DateTime? closedAt;
        private string description;
        private Domain.Interop.API.Common.Models.Display.PropertyDisplayModel vehicle;

        public PropertyLeaseOfferConfigurationPageModel(PropertyLeaseOfferDisplayModel model) : base(model)
        {
            if (model == null) return;

            Priority = model.Priority;
            OpenAt = model.OpenAt;
            ClosedAt = model.ClosedAt;
            Description = model.Description;
            Property = model.Property;
            OrganizationPostulations = model.OrganizationPostulations.ToObservableCollection();
            PersonPostulations = model.PersonPostulations.ToObservableCollection();
        }

        public System.Guid Id { get; set; }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public System.DateTime OpenAt { get => openAt; set => SetProperty(ref openAt, value); }

        public System.DateTime? ClosedAt { get => closedAt; set => SetProperty(ref closedAt, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public Domain.Interop.API.Common.Models.Display.PropertyDisplayModel Property { get => vehicle; set => SetProperty(ref vehicle, value); }

        public System.Collections.ObjectModel.ObservableCollection<CommonLeaseOrganizationPostulationDisplayModel> OrganizationPostulations { get; set; } = [];

        public System.Collections.ObjectModel.ObservableCollection<CommonLeasePersonPostulationDisplayModel> PersonPostulations { get; set; } = [];
    }
}
