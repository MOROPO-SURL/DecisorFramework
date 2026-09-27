namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Web.Backend.Models.View.Display
{
    public class ProductionSampleDisplayViewModel : Interop.API.Common.Models.Display.ProductionSampleDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.ProductionSample entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}
