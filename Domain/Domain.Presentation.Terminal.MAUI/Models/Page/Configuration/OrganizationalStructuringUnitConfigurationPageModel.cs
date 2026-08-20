using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Models.Page.Configuration;

public class OrganizationalStructuringUnitConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<OrganizationalStructuringUnitConfigurationPageModel>
{
    private string reference;
    private Interop.API.Common.Models.Display.OrganizationalUnitDisplayModel organizationalUnit;

    public OrganizationalStructuringUnitConfigurationPageModel(OrganizationalStructuringUnitConfigurationPageModel model) : base(model)
    {
        if (model == null) return;

        Id = model.Id;
        Kind = model.Kind;
        reference = model.Reference;
        organizationalUnit = model.OrganizationalUnit;
        Parent = model.Parent;
        IncomingInteropChildren = model.IncomingInteropChildren;
        EditionInteropChildren = model.EditionInteropChildren;
        OutgoingInteropChildren = model.OutgoingInteropChildren;
    }

    public System.Guid Id { get; set; } = System.Guid.NewGuid();

    public Persistence.Enumerations.OrganizationalStructuringUnitKind Kind { get; set; }

    public OrganizationalStructuringUnitConfigurationPageModel Parent { get; set; }

    public string Reference { get => reference; set => SetProperty(ref reference, value); }

    public Interop.API.Common.Models.Display.OrganizationalUnitDisplayModel OrganizationalUnit { get => organizationalUnit; set => SetProperty(ref organizationalUnit, value); }

    public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Display.OrganizationalUnitDisplayModel> AvailableOrganizationalUnits { get; set; } = [];

    public System.Collections.ObjectModel.ObservableCollection<OrganizationalStructuringUnitConfigurationPageModel> DependencyChildren { get; set; } = [];

    public System.Collections.ObjectModel.ObservableCollection<OrganizationalStructuringUnitConfigurationPageModel> CompositionChildren { get; set; } = [];

    public List<OrganizationalStructuringUnitConfigurationPageModel> EditionInteropChildren { get; private set; } = [];
    public List<OrganizationalStructuringUnitConfigurationPageModel> IncomingInteropChildren { get; private set; } = [];
    public List<OrganizationalStructuringUnitConfigurationPageModel> OutgoingInteropChildren { get; private set; } = [];

    public override bool Equals(object obj)
    {
        return Id.Equals(((OrganizationalStructuringUnitConfigurationPageModel)obj).Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
