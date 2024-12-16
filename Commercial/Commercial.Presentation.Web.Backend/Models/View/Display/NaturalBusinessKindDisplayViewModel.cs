namespace MOROPO.Framework.Decisor.Commercial.Presentation.Web.Backend.Models.View.Display
{
    public class NaturalBusinessKindDisplayViewModel : Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel
    {
        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.NaturalBusinessKind entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}
