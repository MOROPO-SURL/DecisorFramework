namespace MOROPO.ISCamaguey.Decisor.Terminal.Models.Page;

public class SimplfiedDomainDashboardPageModel : Framework.Caney.MVVM.Core.Models.Page.BasePageModel
{
    private bool hasAnyOrganizationalUnit;
    private bool hasAnyOrganiuzationalStructure;
    private bool hasAnyAdministrativeEntityKind;
    private bool hasAnyAdministrativeEntity;
    private bool isModuleReady;

    public bool HasAnyOrganizationalUnit { get => hasAnyOrganizationalUnit; set => SetProperty(ref hasAnyOrganizationalUnit, value); }

    public bool HasAnyOrganiuzationalStructure { get => hasAnyOrganiuzationalStructure; set => SetProperty(ref hasAnyOrganiuzationalStructure, value); }

    public bool HasAnyAdministrativeEntityKind { get => hasAnyAdministrativeEntityKind; set => SetProperty(ref hasAnyAdministrativeEntityKind, value); }

    public bool HasAnyAdministrativeEntity { get => hasAnyAdministrativeEntity; set => SetProperty(ref hasAnyAdministrativeEntity, value); }

    public bool IsModuleReady { get => isModuleReady; set => SetProperty(ref isModuleReady, value); }
}
