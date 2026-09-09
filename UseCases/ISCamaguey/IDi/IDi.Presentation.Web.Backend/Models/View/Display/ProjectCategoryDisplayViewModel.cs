namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Backend.Models.View.Display;

public class ProjectCategoryDisplayViewModel : Interop.API.Common.Models.Display.ProjectCategoryDisplayModel
{
    public bool Archived { get; set; }

    public override void Import(Persistence.Entities.ProjectCategory entity)
    {
        base.Import(entity);

        Archived = entity.Archived;
    }
}