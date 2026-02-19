namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Models.Page.Configuration;

public class OrganizationalStructureConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.OrganizationalStructureDisplayModel>
{
    public static string NameValidableProperty => nameof(Name);
    public static string OrganizationalStructuringUnitConfigurationValidableProperty => nameof(OrganizationalStructuringUnitConfiguration);

    private string name;
    private int priority = 1;
    private OrganizationalStructuringUnitConfigurationPageModel organizationalStructuringUnitConfiguration;

    public OrganizationalStructureConfigurationPageModel(Interop.API.Common.Models.Display.OrganizationalStructureDisplayModel model) : base(model)
    {
        if (model == null) return;

        Id = model.Id;
        name = model.Name;
        priority = model.Priority;
        organizationalStructuringUnitConfiguration = OrganizationalStructureConfigurationPageModel.GetConfiguration(model.RootStructuringUnit, null);
    }

    public System.Guid Id { get; set; }

    public string Name { get => name; set => SetProperty(ref name, value); }

    public int Priority { get => priority; set => SetProperty(ref priority, value); }

    public OrganizationalStructuringUnitConfigurationPageModel OrganizationalStructuringUnitConfiguration { get => organizationalStructuringUnitConfiguration; set => SetProperty(ref organizationalStructuringUnitConfiguration, value); }

    private static OrganizationalStructuringUnitConfigurationPageModel GetConfiguration(Interop.API.Common.Models.Display.OrganizationalStructuringUnitDisplayModel model, OrganizationalStructuringUnitConfigurationPageModel parent)
    {
        var result = new OrganizationalStructuringUnitConfigurationPageModel(null)
        {
            Id = model.Id,
            Reference = model.Reference,
            OrganizationalUnit = model.OrganizationalUnit,
            Parent = parent
        };

        foreach (var _model in model.Children)
        {
            result.Children.Add(GetConfiguration(_model, result));
        }

        return result;
    }
}