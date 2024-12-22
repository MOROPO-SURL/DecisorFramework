namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Backend.Models.View.Display
{
    public class VehicleEngineKindDisplayViewModel : Interop.API.Common.Models.Display.VehicleEngineKindDisplayModel
    {
        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.VehicleEngineKind entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}
