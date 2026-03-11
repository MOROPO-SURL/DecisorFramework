using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class WorkPositionConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<WorkPositionDisplayModel>
    {
        private string name;
        private string reference;
        private string description;
        private int priority = 1;
        private WorkPositionKindDisplayModel kind;
        private Domain.Persistence.Enumerations.EducationLevel educationLevel;

        public WorkPositionConfigurationPageModel(WorkPositionDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                name = model.Name;
                educationLevel = model.EducationLevel;
                kind = model.Kind;
                reference = model.Reference;
                description = model.Description;
                priority = model.Priority;
            }
        }

        public System.Guid Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Reference { get => reference; set => SetProperty(ref reference, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public WorkPositionKindDisplayModel Kind { get => kind; set => SetProperty(ref kind, value); }

        public Domain.Persistence.Enumerations.EducationLevel EducationLevel { get => educationLevel; set => SetProperty(ref educationLevel, value); }

        public WorkPositionKindDisplayModel[] AvailableKinds { get; set; }
    }
}
