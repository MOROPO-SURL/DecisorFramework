namespace MOROPO.Framework.Decisor.Core.Presentation.Web.Backend.Models.View.Display
{
    public class NaturalProviderDisplayViewModel : Core.Web.API.Common.Models.Display.NaturalProviderDisplayModel
    {
        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.NaturalProvider entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}
