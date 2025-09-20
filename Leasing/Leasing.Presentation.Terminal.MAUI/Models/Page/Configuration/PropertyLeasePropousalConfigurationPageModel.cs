using CommunityToolkit.Maui.Core.Extensions;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class PropertyLeasePropousalConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<PropertyLeasePropousalDisplayModel>
    {
        public static string PropertyValidableProperty => nameof(Property);
        public static string DescriptionValidableProperty => nameof(Description);
        public static string SpacePropousalsValidableProperty => nameof(SpacePropousals);
        public static string AuthorValidableProperty => nameof(Author);
        public static string AgreementValidableProperty => nameof(Agreement);

        private int priority = 1;
        private string description;
        private Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel author;
        private Governance.Interop.API.Common.Models.Display.AgreementDisplayModel agreement;
        private Domain.Interop.API.Common.Models.Display.PropertyDisplayModel property;

        public PropertyLeasePropousalConfigurationPageModel(PropertyLeasePropousalDisplayModel model) : base(model)
        {
            if (model == null) return;

            Id = model.Id;
            Priority = model.Priority;
            Description = model.Description;
            Author = model.Author;
            Agreement = model.Agreement;
            Property = model.Property;
            SpacePropousals = model.SpacePropousals.ToObservableCollection();
        }

        public System.Guid Id { get; set; }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel Author { get => author; set => SetProperty(ref author, value); }

        public Governance.Interop.API.Common.Models.Display.AgreementDisplayModel Agreement { get => agreement; set => SetProperty(ref agreement, value); }

        public Domain.Interop.API.Common.Models.Display.PropertyDisplayModel Property { get => property; set => SetProperty(ref property, value); }

        public System.Collections.ObjectModel.ObservableCollection<PropertySpaceLeasePropousalDisplayModel> SpacePropousals { get; set; } = [];
    }
}
