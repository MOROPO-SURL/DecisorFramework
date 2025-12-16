namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class ElaborationStepConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.ElaborationStepDisplayModel>
    {
        public static string NameValidableProperty => nameof(Name);
        public static string DescriptionValidableProperty => nameof(Description);
        public static string MinDecreaseValidableProperty => nameof(MinDecrease);
        public static string MaxDecreaseValidableProperty => nameof(MaxDecrease);
        public static string WorkPositionsValidableProperty => nameof(WorkPositions);

        private string name;
        private string description;
        private int priority = 1;
        private decimal minDecrease;
        private decimal maxDecrease;

        public ElaborationStepConfigurationPageModel(Interop.API.Common.Models.Display.ElaborationStepDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Name = model.Name;
                Description = model.Description;
                Priority = model.Priority;
                MinDecrease = model.MinDecrease;
                MaxDecrease = model.MaxDecrease;

                WorkPositions = [.. model.WorkPositions];
            }
        }

        public System.Guid Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public decimal MinDecrease { get => minDecrease; set => SetProperty(ref minDecrease, value); }

        public decimal MaxDecrease { get => maxDecrease; set => SetProperty(ref maxDecrease, value); }

        public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Bridge.ElaborationStepWorkPositionBridgeModel> WorkPositions { get; set; } = [];
    }
}
