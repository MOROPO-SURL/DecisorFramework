namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Models.View.Display
{
    public class IndicatorDisplayViewModel : Interop.API.Common.Models.Display.IndicatorDisplayModel
    {
        public bool Archived { get; set; }

        public ActionDisplayViewModel Action { get; set; }

        public override void Import(Prototype.Persistence.Entities.Indicator entity)
        {
            base.Import(entity);

            Archived = entity.Archived;

            if (entity.Action != null)
            {
                Action = new ActionDisplayViewModel();

                Action.Import(entity.Action);
            }
        }
    }
}
