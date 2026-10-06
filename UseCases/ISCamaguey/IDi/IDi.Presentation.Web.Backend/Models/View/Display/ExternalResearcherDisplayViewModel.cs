namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Backend.Models.View.Display
{
    public class ExternalResearcherDisplayViewModel : Interop.API.Common.Models.Display.ExternalResearcherDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.ExternalResearcher entity)
        {
            base.Import(entity);

            Archived = entity.Archived;
        }
    }
}
