using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class VacantConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<VacantDisplayModel>
    {
        private string name;
        private string reference;
        private string description;
        private int priority = 1;
        private VacantKindDisplayModel kind;
        private SchoolingDisplayModel schooling;

        public VacantConfigurationPageModel(VacantDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Name = model.Name;
                Schooling = model.Schooling;
                Kind = model.Kind;
                Reference = model.Reference;
                Description = model.Description;
                Priority = model.Priority;
            }
        }

        public System.Guid Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Reference { get => reference; set => SetProperty(ref reference, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public VacantKindDisplayModel Kind { get => kind; set => SetProperty(ref kind, value); }

        public SchoolingDisplayModel Schooling { get => schooling; set => SetProperty(ref schooling, value); }

        public VacantKindDisplayModel[] AvailableKinds { get; set; }

        public SchoolingDisplayModel[] AvailableSchoolings { get; set; }
    }
}
