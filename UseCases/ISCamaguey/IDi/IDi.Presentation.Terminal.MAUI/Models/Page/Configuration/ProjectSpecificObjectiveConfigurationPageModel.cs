using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Models.Page.Configuration;

public sealed class ProjectSpecificObjectiveConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<ProjectSpecificObjectiveDisplayModel>
{
    public static string NameValidableProperty => nameof(Name);
    public static string DescriptionValidableProperty => nameof(Description);

    private int index = 1;
    private string name;
    private string description;

    public ProjectSpecificObjectiveConfigurationPageModel(ProjectSpecificObjectiveDisplayModel model) : base(model)
    {
        if (model == null) return;

        Id = model.Id;
        name = model.Name;
        index = model.Index;
        description = model.Description;
    }

    public System.Guid Id { get; set; }

    public int Index { get => index; set => SetProperty(ref index, value); }

    public string Name { get => name; set => SetProperty(ref name, value); }

    public string Description { get => description; set => SetProperty(ref description, value); }
}