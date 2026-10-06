namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Backend.Models.View.Display
{
    public class ParticipatingOrganizationDisplayViewModel : Interop.API.Common.Models.Display.ParticipatingOrganizationDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.ParticipatingOrganization entity)
        {
            base.Import(entity);

            Archived = entity.Archived;
        }
    }
}
