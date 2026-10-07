using MOROPO.Framework.Decisor.Inventory.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Inventory.Presentation.Web.Backend.Models.View.Display;

public sealed class ProductDisplayViewModel : Interop.API.Common.Models.Display.ProductDisplayModel
{
    public bool Enabled { get; set; }

    public bool Archived { get; set; }

    public override void Import(Product entity)
    {
        base.Import(entity);

        Enabled = entity.Enabled;
        Archived = entity.Archived;
    }
}
