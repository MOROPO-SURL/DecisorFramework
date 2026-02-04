using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Extensions;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Models.Page.Configuration;

public class StructureConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.StructureParentalDisplayModel>
{
    public static string NameValidableProperty => nameof(Name);
    public static string KindValidableProperty => nameof(Kind);

    private string name;
    private string about;
    private int priority = 1;
    private Microsoft.Maui.Controls.ImageSource imageSource;
    private Interop.API.Common.Models.Display.StructureKindDisplayModel kind;
    private Interop.API.Common.Models.Display.StructureParentalDisplayModel parent;

    public StructureConfigurationPageModel(Interop.API.Common.Models.Display.StructureParentalDisplayModel model) : base(model)
    {
        if (model != null)
        {
            Id = model.Id;
            Name = model.Identity.Name;
            About = model.Identity.About;
            Priority = model.Priority;
            Kind = model.Kind;
            Parent = model.Parent;
            OrganizationalUnities = new System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Display.OrganizationalUnityTreeDisplayModel>(model.OrganizationalUnities);

            if (model.Identity.Image != null)
            {
                ImageId = model.Identity.Image.Id;
                ImageSource = model.Identity.Image.ToImageSource();
            }
        }
    }

    public System.Guid Id { get; set; }

    public System.Guid? ImageId { get; set; }

    public string Name { get => name; set => SetProperty(ref name, value); }

    public string About { get => about; set => SetProperty(ref about, value); }

    public int Priority { get => priority; set => SetProperty(ref priority, value); }

    public Microsoft.Maui.Controls.ImageSource ImageSource { get => imageSource; set => SetProperty(ref imageSource, value); }

    public Interop.API.Common.Models.Display.StructureKindDisplayModel Kind { get => kind; set => SetProperty(ref kind, value); }

    public Interop.API.Common.Models.Display.StructureParentalDisplayModel Parent { get => parent; set => SetProperty(ref parent, value); }

    public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Display.OrganizationalUnityTreeDisplayModel> OrganizationalUnities { get; set; } = [];

    public Interop.API.Common.Models.Display.StructureKindDisplayModel[] AvailableKinds { get; set; }

    public Interop.API.Common.Models.Display.StructureParentalDisplayModel[] AvailableParents { get; set; }
}
