namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Models.Page.Configuration;

public class AcademicAchievementConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.AcademicAchievementDisplayModel>
{
    public AcademicAchievementConfigurationPageModel(Interop.API.Common.Models.Display.AcademicAchievementDisplayModel model) : base(model)
    {
        if (model == null) return;


    }

    public System.Guid Id { get; set; }
}
