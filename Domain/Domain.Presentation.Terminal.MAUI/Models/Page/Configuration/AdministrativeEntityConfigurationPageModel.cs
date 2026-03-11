using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Extensions;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Models.Page.Configuration;

public class AdministrativeEntityConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.AdministrativeEntityParentalDisplayModel>
{
    public static string NameValidableProperty => nameof(Name);
    public static string KindValidableProperty => nameof(Kind);
    public static string OrganizationalStructureValidableProperty => nameof(OrganizationalStructure);

    private string name;
    private string about;
    private int priority = 1;
    private Microsoft.Maui.Controls.ImageSource imageSource;
    private Interop.API.Common.Models.Display.AdministrativeEntityKindDisplayModel kind;
    private Interop.API.Common.Models.Display.OrganizationalStructureDisplayModel organizationalStructure;
    private Interop.API.Common.Models.Display.AdministrativeEntityParentalDisplayModel parent;

    public AdministrativeEntityConfigurationPageModel(Interop.API.Common.Models.Display.AdministrativeEntityParentalDisplayModel model) : base(model)
    {
        if (model != null)
        {
            Id = model.Id;
            name = model.Identity.Name;
            about = model.Identity.About;
            priority = model.Priority;
            kind = model.Kind;
            organizationalStructure = model.OrganizationalStructure;
            parent = model.Parent;

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

    public Interop.API.Common.Models.Display.AdministrativeEntityKindDisplayModel Kind { get => kind; set => SetProperty(ref kind, value); }

    public Interop.API.Common.Models.Display.OrganizationalStructureDisplayModel OrganizationalStructure { get => organizationalStructure; set => SetProperty(ref organizationalStructure, value); }

    public Interop.API.Common.Models.Display.AdministrativeEntityParentalDisplayModel Parent { get => parent; set => SetProperty(ref parent, value); }

    public Interop.API.Common.Models.Display.AdministrativeEntityKindDisplayModel[] AvailableKinds { get; set; }

    public Interop.API.Common.Models.Display.OrganizationalStructureDisplayModel[] AvailableOrganizationalStructures { get; set; }

    public Interop.API.Common.Models.Display.AdministrativeEntityParentalDisplayModel[] AvailableParents { get; set; }
}
