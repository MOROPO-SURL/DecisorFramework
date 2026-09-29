using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Models.Page.Configuration;

public sealed class AwardResultConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<AwardResultDisplayModel>
{
    public static Persistence.Enumerations.AwardModality[] AVAILABLE_AWARD_MODALITIES = [ Persistence.Enumerations.AwardModality.Institutional, Persistence.Enumerations.AwardModality.Individual ];

    public static string TitleValidableProperty => nameof(Title);
    public static string DocumentValidableProperty => nameof(Receptor);
    public static string AwardKindValidableProperty => nameof(AwardKind);

    private string title;
    private AwardKindDisplayModel awardKind;
    private Persistence.Enumerations.AwardModality awardModality;
    private string description;
    private System.DateTime at = System.DateTime.Now;
    private ProjectDisplayModel project;
    private EmployeeDisplayModel receptor;

    public AwardResultConfigurationPageModel(AwardResultDisplayModel model, IEnumerable<AwardKindDisplayModel> availableAwardKinds) : base(model)
    {
        AvailableAwardKinds = [.. availableAwardKinds];

        if (model == null) return;

        Id = model.Id;
        title = model.Title;
        awardKind = AvailableAwardKinds.SingleOrDefault(item => item.Id == model.AwardKind.Id);
        awardModality = model.AwardModality;
        description = model.Description;
        at = model.At;
        project = model.Project;
        receptor = model.Receptor;
    }

    public System.Guid Id { get; set; }

    public string Title { get => title; set => SetProperty(ref title, value); }

    public Persistence.Enumerations.AwardModality AwardModality { get => awardModality; set => SetProperty(ref awardModality, value); }

    public AwardKindDisplayModel AwardKind { get => awardKind; set => SetProperty(ref awardKind, value); }

    public string Description { get => description; set => SetProperty(ref description, value); }

    public EmployeeDisplayModel Receptor { get => receptor; set => SetProperty(ref receptor, value); }

    public System.DateTime At { get => at; set => SetProperty(ref at, value); }

    public ProjectDisplayModel Project { get => project; set => SetProperty(ref project, value); }

    public ObservableCollection<AwardKindDisplayModel> AvailableAwardKinds { get; init; }
}