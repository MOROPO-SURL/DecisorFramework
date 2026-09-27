namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Web.Backend.Models.View.Display
{
    public class ServiceOrderSampleDisplayViewModel : Interop.API.Common.Models.Display.ServiceOrderSampleDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.ServiceOrderSample entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}
