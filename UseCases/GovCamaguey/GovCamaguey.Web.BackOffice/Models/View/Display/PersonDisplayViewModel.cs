namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Models.View.Display
{
    public class PersonDisplayViewModel : Interop.API.Common.Models.Display.PersonDisplayModel
    {
        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public override void Import(Prototype.Persistence.Entities.Person entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}
