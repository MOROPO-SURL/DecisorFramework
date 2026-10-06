namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Backend.Models.View.Display
{
    public class ScientificTechnicalResultDisplayViewModel : Interop.API.Common.Models.Display.ScientificTechnicalResultDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.ScientificTechnicalResult entity)
        {
            base.Import(entity);

            Archived = entity.Archived;
        }
    }
}
