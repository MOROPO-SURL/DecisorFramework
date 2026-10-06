using MOROPO.ISCamaguey.Decisor.Recommending.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Recommending.Presentation.Web.Backend.Models.View.Display;

public sealed class RecomendationReportDisplayViewModel : Interop.API.Common.Models.Display.RecomendationReportDisplayModel
{
    public bool Archived { get; set; }

    public override void Import(RecomendationReport entity)
    {
        base.Import(entity);

        Archived = entity.Archived;
    }
}
