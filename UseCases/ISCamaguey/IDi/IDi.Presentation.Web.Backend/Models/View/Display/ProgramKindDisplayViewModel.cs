namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Backend.Models.View.Display;

public class ProgramKindDisplayViewModel : Interop.API.Common.Models.Display.ProgramKindDisplayModel
{
    public bool Archived { get; set; }

    public override void Import(Persistence.Entities.ProgramKind entity)
    {
        base.Import(entity);

        Archived = entity.Archived;
    }
}
