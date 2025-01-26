namespace MOROPO.Framework.Decisor.Production.Presentation.Web.Backend.Models.View.Display
{
    public class ProductionDisplayViewModel : Interop.API.Common.Models.Display.ProductionDisplayModel
    {
        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.Production entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}

