namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Models.View.Display
{
    public class ActionIndicatorResultDisplayViewModel : Interop.API.Common.Models.Display.ActionIndicatorResultDisplayModel
    {
        public IndicatorDisplayViewModel Indicator { get; set; }

        public override void Import(Prototype.Persistence.Entities.ActionIndicatorResult entity)
        {
            base.Import(entity);

            if (entity.Indicator != null)
            {
                Indicator = new IndicatorDisplayViewModel();

                Indicator.Import(entity.Indicator);
            }
        }
    }
}
