namespace MOROPO.ISCamaguey.Decisor.Production.Presentation.Web.Backend.Models.View.Display;

public class ProductionQualityCheckDisplayViewModel : Interop.API.Common.Models.Display.ProductionQualityCheckDisplayModel
{
    public bool Archived { get; set; }

    public override void Import(Persistence.Entities.ProductionQualityCheck entity)
    {
        base.Import(entity);

        Archived = entity.Archived;
    }
}
