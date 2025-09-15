namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Models.View.Display
{
    public class OrganizationDisplayViewModel : Interop.API.Common.Models.Display.OrganizationDisplayModel
    {
        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public override void Import(Prototype.Persistence.Entities.Organization entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}
