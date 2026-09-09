using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.Models.Page.Configuration;

public sealed class WorkPlanConfigurationPageModel : AbstractConfigurationPageModel<WorkPlanDisplayModel>
{
    public static string WorkingGroupValidableProperty => nameof(WorkingGroup);
    public static string ServiceOrderSamplesValidableProperty => nameof(ServiceOrderSamples);
    public static string ResearchSamplesValidableProperty => nameof(ResearchSamples);
    public static string ProductionSamplesValidableProperty => nameof(ProductionSamples);

    private System.DateTime at;
    private string description;
    private WorkingGroupDisplayModel workingGroup;

    public WorkPlanConfigurationPageModel(WorkPlanDisplayModel model, IEnumerable<WorkingGroupDisplayModel> availableWorkingGroups) : base(model)
    {
        AvailableWorkingGroups = availableWorkingGroups;

        At = System.DateTime.Now;

        if (model == null) return;

        Id = model.Id;

        at = model.At;
        description = model.Description;
        workingGroup = AvailableWorkingGroups.Single(item => item.Id == model.WorkingGroup.Id);

        ServiceOrderSamples = [.. model.ServiceOrderSamples];
        ResearchSamples = [.. model.ResearchSamples];
        ProductionSamples = [.. model.ProductionSamples];
    }

    public System.Guid Id { get; set; }

    public System.DateTime At { get => at; set => SetProperty(ref at, value); }

    public string Description { get => description; set => SetProperty(ref description, value); }

    public WorkingGroupDisplayModel WorkingGroup { get => workingGroup; set => SetProperty(ref workingGroup, value); }

    public ObservableCollection<ServiceOrderSampleDisplayModel> ServiceOrderSamples { get; init; } = [];

    public ObservableCollection<ResearchSampleDisplayModel> ResearchSamples { get; init; } = [];

    public ObservableCollection<ProductionSampleDisplayModel> ProductionSamples { get; init; } = [];

    public IEnumerable<WorkingGroupDisplayModel> AvailableWorkingGroups { get; init; }
}
