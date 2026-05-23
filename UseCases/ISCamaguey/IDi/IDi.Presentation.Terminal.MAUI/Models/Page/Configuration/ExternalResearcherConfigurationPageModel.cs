namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class ExternalResearcherConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.ExternalResearcherDisplayModel>
    {
        public static string ContactValidableProperty => nameof(Contact);
        public static string ParticipatingOrganizationValidableProperty => nameof(ParticipatingOrganization);
        public static string TimeAvailabilityValidableProperty => nameof(TimeAvailability);
        public static string SalaryValidableProperty => nameof(Salary);

        private Framework.Decisor.Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel contact;
        private Interop.API.Common.Models.Display.ParticipatingOrganizationDisplayModel participatingOrganization;
        private Interop.API.Common.Models.Display.ResearcherCategoryDisplayModel category;
        private Interop.API.Common.Models.Display.TeachingCategoryDisplayModel teachingCategory;
        private int timeAvailability = 8;
        private decimal salary;
        private int priority = 1;

        public ExternalResearcherConfigurationPageModel(Interop.API.Common.Models.Display.ExternalResearcherDisplayModel model) : base(model)
        {
            if (model == null) return;

            Id = model.Id;
            contact = model.Contact;
            participatingOrganization = model.ParticipatingOrganization;
            category = model.Category;
            teachingCategory = model.TeachingCategory;
            timeAvailability = model.TimeAvailability;
            salary = model.Salary;
            priority = model.Priority;
        }

        public System.Guid Id { get; set; }

        public Framework.Decisor.Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel Contact { get => contact; set => SetProperty(ref contact, value); }

        public Interop.API.Common.Models.Display.ParticipatingOrganizationDisplayModel ParticipatingOrganization { get => participatingOrganization; set => SetProperty(ref participatingOrganization, value); }

        public Interop.API.Common.Models.Display.ResearcherCategoryDisplayModel Category { get => category; set => SetProperty(ref category, value); }

        public Interop.API.Common.Models.Display.TeachingCategoryDisplayModel TeachingCategory { get => teachingCategory; set => SetProperty(ref teachingCategory, value); }

        public int TimeAvailability { get => timeAvailability; set => SetProperty(ref timeAvailability, value); }

        public decimal Salary { get => salary; set => SetProperty(ref salary, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public Interop.API.Common.Models.Display.ResearcherCategoryDisplayModel[] AvailableResearcherCategories { get; set; }

        public Interop.API.Common.Models.Display.TeachingCategoryDisplayModel[] AvailableTeachingCategories { get; set; }
    }
}
