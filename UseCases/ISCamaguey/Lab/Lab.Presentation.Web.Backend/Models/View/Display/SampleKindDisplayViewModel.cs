namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Web.Backend.Models.View.Display
{
    public class SampleKindDisplayViewModel : Interop.API.Common.Models.Display.SampleKindDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.SampleKind entity)
        {
            base.Import(entity);

            Archived = entity.Archived;
        }
    }
}
