namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Models.Page.Configuration;

public class AcademicAchievementConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.AcademicAchievementDisplayModel>
{
    public static string MainKnowledgeAreaValidableProperty => nameof(MainKnowledgeArea);
    public static string TitleValidableProperty => nameof(Title);
    public static string InstitutionValidableProperty => nameof(Institution);

    private Interop.API.Common.Models.Display.KnowledgeAreaDisplayModel mainKnowledgeArea;
    private string title;
    private System.DateTime at;
    private bool isAtSet;
    private string institution;

    public AcademicAchievementConfigurationPageModel(Persistence.Enumerations.AcademicLevel academicLevel, Interop.API.Common.Models.Display.AcademicAchievementDisplayModel model) : base(model)
    {
        if (model == null)
        {
            at = System.DateTime.Now;

            return;
        }

        Id = model.Id;
        AcademicLevel = academicLevel;

        mainKnowledgeArea = model.MainKnowledgeArea;
        title = model.Title;
        isAtSet = model.At != null;
        at = model.At ?? System.DateTime.Now;

        ExtraKnowledgeAreas = [.. model.ExtraKnowledgeAreas];
    }

    public System.Guid Id { get; set; }

    public Persistence.Enumerations.AcademicLevel AcademicLevel { get; set; }

    public Interop.API.Common.Models.Display.KnowledgeAreaDisplayModel MainKnowledgeArea { get => mainKnowledgeArea; set => SetProperty(ref mainKnowledgeArea, value); }

    public string Title { get => title; set => SetProperty(ref title, value); }

    public System.DateTime At { get => at; set => SetProperty(ref at, value); }

    public bool IsAtSet { get => isAtSet; set => SetProperty(ref isAtSet, value); }

    public string Institution { get => institution; set => SetProperty(ref institution, value); }

    public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Display.KnowledgeAreaDisplayModel> ExtraKnowledgeAreas { get; set; } = [];
}
