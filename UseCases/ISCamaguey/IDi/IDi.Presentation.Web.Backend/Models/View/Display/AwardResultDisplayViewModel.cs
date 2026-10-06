namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Backend.Models.View.Display
{
    public class AwardResultDisplayViewModel : Interop.API.Common.Models.Display.AwardResultDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.AwardResult entity)
        {
            base.Import(entity);

            Archived = entity.Archived;
        }
    }
}
