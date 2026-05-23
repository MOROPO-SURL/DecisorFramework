namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class InternalResearcherConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.InternalResearcherDisplayModel>
    {
        public static string EmployeeValidableProperty => nameof(Employee);
        public static string TimeAvailabilityValidableProperty => nameof(TimeAvailability);

        private Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel employee;
        private Interop.API.Common.Models.Display.ResearcherCategoryDisplayModel category;
        private Interop.API.Common.Models.Display.TeachingCategoryDisplayModel teachingCategory;
        private int timeAvailability = 8;
        private int priority = 1;

        public InternalResearcherConfigurationPageModel(Interop.API.Common.Models.Display.InternalResearcherDisplayModel model) : base(model)
        {
            if (model == null) return;

            Id = model.Id;
            employee = model.Employee;
            category = model.Category;
            teachingCategory = model.TeachingCategory;
            timeAvailability = model.TimeAvailability;
            priority = model.Priority;
        }

        public System.Guid Id { get; set; }

        public Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel Employee { get => employee; set => SetProperty(ref employee, value); }

        public Interop.API.Common.Models.Display.ResearcherCategoryDisplayModel Category { get => category; set => SetProperty(ref category, value); }

        public Interop.API.Common.Models.Display.TeachingCategoryDisplayModel TeachingCategory { get => teachingCategory; set => SetProperty(ref teachingCategory, value); }

        public int TimeAvailability { get => timeAvailability; set => SetProperty(ref timeAvailability, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public Interop.API.Common.Models.Display.ResearcherCategoryDisplayModel[] AvailableResearcherCategories { get; set; }

        public Interop.API.Common.Models.Display.TeachingCategoryDisplayModel[] AvailableTeachingCategories { get; set; }
    }
}
