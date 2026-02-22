using System.Linq;

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
            Kind = model.Kind,
            Reference = model.Reference,
            OrganizationalUnit = model.OrganizationalUnit,
            Parent = parent
        };

        var dependencyChildren = model.Children.Where(_model => _model.Kind == Persistence.Enumerations.OrganizationalStructuringUnitKind.Dependency).ToArray();
        var compositionChildren = model.Children.Where(_model => _model.Kind == Persistence.Enumerations.OrganizationalStructuringUnitKind.Composition).ToArray();

        foreach (var _model in dependencyChildren)
        {
            result.DependencyChildren.Add(GetConfiguration(_model, result));
        }

        foreach (var _model in compositionChildren)
        {
            result.CompositionChildren.Add(GetConfiguration(_model, result));
        }

        return result;
    }
}