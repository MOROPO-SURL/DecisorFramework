using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Recommending.Interop.API.Common.Models.Display;
using System.Collections.ObjectModel;

namespace MOROPO.ISCamaguey.Decisor.Recommending.Presentation.Terminal.MAUI.Models.Page.Configuration;

public sealed class RecomendationReportConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<RecomendationReportDisplayModel>
{
    public static string TitleValidableProperty => nameof(Title);
    public static string DocumentValidableProperty => nameof(Document);
    public static string AuthorsValidableProperty => nameof(Authors);

    private string title;
    private string reference;
    private string description;
    private System.DateTime at = System.DateTime.Now;
    private DocumentDisplayModel document;

    public RecomendationReportConfigurationPageModel(RecomendationReportDisplayModel model) : base(model)
    {
        if (model == null) return;

        Id = model.Id;
        title = model.Title;
        reference = model.Reference;
        description = model.Description;
        at = model.At;
        document = model.Document;

        Authors = [.. model.Authors];
    }

    public System.Guid Id { get; set; }

    public string Title { get => title; set => SetProperty(ref title, value); }

    public string Reference { get => reference; set => SetProperty(ref reference, value); }

    public string Description { get => description; set => SetProperty(ref description, value); }

    public DocumentDisplayModel Document { get => document; set => SetProperty(ref document, value); }

    public System.DateTime At { get => at; set => SetProperty(ref at, value); }

    public ObservableCollection<EmployeeDisplayModel> Authors { get; init; } = [];
}