namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Backend.Models.View.Display
{
    public class ScientificTechnicalResultKindDisplayViewModel : Interop.API.Common.Models.Display.ScientificTechnicalResultKindDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.ScientificTechnicalResultKind entity)
        {
            base.Import(entity);

            Archived = entity.Archived;
        }
    }
}
