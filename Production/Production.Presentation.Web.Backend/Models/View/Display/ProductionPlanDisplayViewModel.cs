namespace MOROPO.Framework.Decisor.Production.Presentation.Web.Backend.Models.View.Display
{
    public class ProductionPlanDisplayViewModel : Interop.API.Common.Models.Display.ProductionPlanDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.ProductionPlan entity)
        {
            base.Import(entity);

            Archived = entity.Archived;
        }
    }
}

