using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration;

public sealed class LegalClientVehicleLeasingControlActionConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<LegalClientVehicleLeasingControlActionDisplayModel>
{
    public static string SupervisionGroupValidableProperty => nameof(SupervisionGroup);
    public static string LeasingValidableProperty => nameof(Leasing);
    public static string DescriptionValidableProperty => nameof(Description);

    private System.DateTime at;
    private string description;
    private SupervisionGroupDisplayModel supervisionGroup;
    private LegalClientVehicleLeasingDisplayModel leasing;

    public LegalClientVehicleLeasingControlActionConfigurationPageModel(LegalClientVehicleLeasingControlActionDisplayModel model, IEnumerable<SupervisionGroupDisplayModel> availableSupervisionGroups) : base(model)
    {
        AvailableSupervisionGroups = [.. availableSupervisionGroups];

        Id = model?.Id ?? default;
        at = model?.At ?? System.DateTime.Now;
        description = model?.Description;
        supervisionGroup = model?.SupervisionGroup == null ? null : AvailableSupervisionGroups.Single(item => item.Id == model.SupervisionGroup.Id);
        leasing = model?.Leasing;
    }

    public System.Guid Id { get; set; }

    public System.DateTime At { get => at; set => SetProperty(ref at, value); }

    public string Description { get => description; set => SetProperty(ref description, value); }

    public SupervisionGroupDisplayModel SupervisionGroup { get => supervisionGroup; set => SetProperty(ref supervisionGroup, value); }

    public LegalClientVehicleLeasingDisplayModel Leasing { get => leasing; set => SetProperty(ref leasing, value); }

    public ObservableCollection<SupervisionGroupDisplayModel> AvailableSupervisionGroups { get; init; }
}
