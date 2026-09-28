namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Web.Backend.Models.View.Display;

public class AssessmentDisplayViewModel : Interop.API.Common.Models.Display.AssessmentDisplayModel
{
    public bool Archived { get; set; }

    public override void Import(Persistence.Entities.Assessment entity)
    {
        base.Import(entity);

        Archived = entity.Archived;
    }
}