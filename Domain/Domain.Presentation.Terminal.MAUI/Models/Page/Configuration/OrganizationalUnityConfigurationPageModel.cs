namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class OrganizationalUnityConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.OrganizationalUnityParentalDisplayModel>
    {
        public static string NameValidableProperty => nameof(Name);

        private string name;
        private string reference;
        private int priority = 1;
        private Interop.API.Common.Models.Display.OrganizationalUnityParentalDisplayModel parent;

        public OrganizationalUnityConfigurationPageModel(Interop.API.Common.Models.Display.OrganizationalUnityParentalDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Name = model.Name;
                Reference = model.Reference;
                Priority = model.Priority;
                Parent = model.Parent;
            }
        }

        public System.Guid Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Reference { get => reference; set => SetProperty(ref reference, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public Interop.API.Common.Models.Display.OrganizationalUnityParentalDisplayModel Parent { get => parent; set => SetProperty(ref parent, value); }

        public Interop.API.Common.Models.Display.OrganizationalUnityParentalDisplayModel[] AvailableParents { get; set; }
    }
}
