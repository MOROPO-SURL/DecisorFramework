namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Backend.Models.View.Display
{
    public class InternalResearcherDisplayViewModel : Interop.API.Common.Models.Display.InternalResearcherDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.InternalResearcher entity)
        {
            base.Import(entity);

            Archived = entity.Archived;
        }
    }
}
