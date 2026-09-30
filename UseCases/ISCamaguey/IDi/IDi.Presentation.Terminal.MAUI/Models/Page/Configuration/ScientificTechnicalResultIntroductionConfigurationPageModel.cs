using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using System.Collections.ObjectModel;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Models.Page.Configuration;

public sealed class ScientificTechnicalResultIntroductionConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<ScientificTechnicalResultIntroductionDisplayModel>
{
    public static string ScenaryValidableProperty => nameof(Scenary);
    public static string ResultValidableProperty => nameof(Result);

    private string scenary;
    private string description;
    private System.DateTime at = System.DateTime.Now;
    private ScientificTechnicalResultDisplayModel result;

    public ScientificTechnicalResultIntroductionConfigurationPageModel(ScientificTechnicalResultIntroductionDisplayModel model) : base(model)
    {
        if (model == null) return;

        Id = model.Id;
        scenary = model.Scenary;
        description = model.Description;
        at = model.At;
        result = model.Result;

        Supervisors = [.. model.Supervisors];
    }

    public System.Guid Id { get; set; }

    public string Scenary { get => scenary; set => SetProperty(ref scenary, value); }

    public string Description { get => description; set => SetProperty(ref description, value); }

    public System.DateTime At { get => at; set => SetProperty(ref at, value); }

    public ScientificTechnicalResultDisplayModel Result { get => result; set => SetProperty(ref result, value); }

    public ObservableCollection<EmployeeDisplayModel> Supervisors { get; init; } = [];
}