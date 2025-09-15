namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Models.View.Display
{
    public class UnitMeasurementDisplayViewModel : Interop.API.Common.Models.Display.UnitMeasurementDisplayModel
    {
        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public override void Import(Prototype.Persistence.Entities.UnitMeasurement entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}
