namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Models.View.Display
{
    public class ResultDisplayViewModel : Interop.API.Common.Models.Display.ResultDisplayModel
    {
        public IndicatorDisplayViewModel Indicator { get; set; }

        public override void Import(Prototype.Persistence.Entities.Result entity)
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
