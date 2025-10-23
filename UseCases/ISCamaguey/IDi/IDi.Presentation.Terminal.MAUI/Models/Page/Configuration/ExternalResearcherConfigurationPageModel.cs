namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class ExternalResearcherConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.ExternalResearcherDisplayModel>
    {
        public static string ContactValidableProperty => nameof(Contact);
        public static string ParticipatingOrganizationValidableProperty => nameof(ParticipatingOrganization);

        private Framework.Decisor.Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel contact;
        private Interop.API.Common.Models.Display.ParticipatingOrganizationDisplayModel participatingOrganization;
        private Interop.API.Common.Models.Display.ResearcherCategoryDisplayModel category;
        private Interop.API.Common.Models.Display.TeachingCategoryDisplayModel teachingCategory;
        private int priority = 1;

        public ExternalResearcherConfigurationPageModel(Interop.API.Common.Models.Display.ExternalResearcherDisplayModel model) : base(model)
        {
            if (model == null) return;

            Id = model.Id;
            contact = model.Contact;
            participatingOrganization = model.ParticipatingOrganization;
            category = model.Category;
            teachingCategory = model.TeachingCategory;
            priority = model.Priority;
            SpecializationResearchAreas = [.. model.SpecializationResearchAreas];
            MasteryResearchAreas = [.. model.MasteryResearchAreas];
            DoctorateResearchAreas = [.. model.DoctorateResearchAreas];
        }

        public System.Guid Id { get; set; }

        public Framework.Decisor.Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel Contact { get => contact; set => SetProperty(ref contact, value); }

        public Interop.API.Common.Models.Display.ParticipatingOrganizationDisplayModel ParticipatingOrganization { get => participatingOrganization; set => SetProperty(ref participatingOrganization, value); }

        public Interop.API.Common.Models.Display.ResearcherCategoryDisplayModel Category { get => category; set => SetProperty(ref category, value); }

        public Interop.API.Common.Models.Display.TeachingCategoryDisplayModel TeachingCategory { get => teachingCategory; set => SetProperty(ref teachingCategory, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Display.ResearchAreaDisplayModel> SpecializationResearchAreas { get; set; } = [];

        public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Display.ResearchAreaDisplayModel> MasteryResearchAreas { get; set; } = [];

        public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Display.ResearchAreaDisplayModel> DoctorateResearchAreas { get; set; } = [];

        public Interop.API.Common.Models.Display.ResearcherCategoryDisplayModel[] AvailableResearcherCategories { get; set; }

        public Interop.API.Common.Models.Display.TeachingCategoryDisplayModel[] AvailableTeachingCategories { get; set; }
    }
}
