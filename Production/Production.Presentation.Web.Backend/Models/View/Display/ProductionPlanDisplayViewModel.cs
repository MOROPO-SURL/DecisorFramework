namespace MOROPO.Framework.Decisor.Production.Presentation.Web.Backend.Models.View.Display
{
    public class ProductionPlanDisplayViewModel : Interop.API.Common.Models.Display.ProductionOrderDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.ProductionOrder entity)
        {
            base.Import(entity);

            Archived = entity.Archived;
        }
    }
}

