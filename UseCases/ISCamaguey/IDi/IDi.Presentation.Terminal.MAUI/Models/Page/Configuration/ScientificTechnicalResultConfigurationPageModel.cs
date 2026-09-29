using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Models.Page.Configuration;

public sealed class ScientificTechnicalResultConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<ScientificTechnicalResultDisplayModel>
{
    public static string TitleValidableProperty => nameof(Title);
    public static string KindValidableProperty => nameof(Kind);

    private string title;
    private string reference;
    private ScientificTechnicalResultKindDisplayModel kind;
    private string description;
    private System.DateTime at = System.DateTime.Now;
    private ProjectDisplayModel project;

    public ScientificTechnicalResultConfigurationPageModel(ScientificTechnicalResultDisplayModel model, IEnumerable<ScientificTechnicalResultKindDisplayModel> availableScientificTechnicalResultKinds) : base(model)
    {
        AvailableScientificTechnicalResultKinds = [.. availableScientificTechnicalResultKinds];

        if (model == null) return;

        Id = model.Id;
        title = model.Title;
        reference = model.Reference;
        kind = AvailableScientificTechnicalResultKinds.SingleOrDefault(item => item.Id == model.Kind.Id);
        description = model.Description;
        at = model.At;
        project = model.Project;
    }

    public System.Guid Id { get; set; }

    public string Title { get => title; set => SetProperty(ref title, value); }

    public string Reference { get => reference; set => SetProperty(ref reference, value); }

    public ScientificTechnicalResultKindDisplayModel Kind { get => kind; set => SetProperty(ref kind, value); }

    public string Description { get => description; set => SetProperty(ref description, value); }

    public System.DateTime At { get => at; set => SetProperty(ref at, value); }

    public ProjectDisplayModel Project { get => project; set => SetProperty(ref project, value); }

    public ObservableCollection<ScientificTechnicalResultKindDisplayModel> AvailableScientificTechnicalResultKinds { get; init; }
}