using MOROPO.Framework.Decisor.Inventory.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Inventory.Presentation.Web.Backend.Models.View.Display;

public sealed class FamilyDisplayViewModel : Interop.API.Common.Models.Display.FamilyDisplayModel
{
    public bool Enabled { get; set; }

    public bool Archived { get; set; }

    public override void Import(Family entity)
    {
        base.Import(entity);

        Enabled = entity.Enabled;
        Archived = entity.Archived;
    }
}
