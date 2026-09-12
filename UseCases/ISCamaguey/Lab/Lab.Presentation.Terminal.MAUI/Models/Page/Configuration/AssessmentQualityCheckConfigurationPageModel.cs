using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.Models.Page.Configuration;

public sealed class AssessmentQualityCheckConfigurationPageModel : AbstractConfigurationPageModel<AssessmentQualityCheckDisplayModel>
{
    public static string AssessmentValidableProperty => nameof(Assessment);
    public static string AuthorValidableProperty => nameof(Author);
    public static string DescriptionValidableProperty => nameof(Description);

    private System.DateTime at;
    private double qualityPercent;
    private string description;
    private AssessmentDisplayModel assessment;
    private EmployeeDisplayModel author;

    public AssessmentQualityCheckConfigurationPageModel(AssessmentQualityCheckDisplayModel model) : base(model)
    {
        at = System.DateTime.Now;
        qualityPercent = 50D;

        if (model == null) return;

        Id = model.Id;
        at = model.At;
        qualityPercent = model.QualityPercent;
        description = model.Description;
        assessment = model.Assessment;
        author = model.Author;
    }

    public System.Guid Id { get; init; }

    public System.DateTime At { get => at; set => SetProperty(ref at, value); }

    public double QualityPercent { get => qualityPercent; set => SetProperty(ref qualityPercent, value); }

    public string Description { get => description; set => SetProperty(ref description, value); }

    public AssessmentDisplayModel Assessment { get => assessment; set => SetProperty(ref assessment, value); }

    public EmployeeDisplayModel Author { get => author; set => SetProperty(ref author, value); }
}