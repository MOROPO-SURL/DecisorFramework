namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Backend.Models.View.Display
{
    public class PublicationResultDisplayViewModel : Interop.API.Common.Models.Display.PublicationResultDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.PublicationResult entity)
        {
            base.Import(entity);

            Archived = entity.Archived;
        }
    }
}
