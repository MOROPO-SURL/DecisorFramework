namespace MOROPO.Framework.Decisor.Core.Presentation.Web.Backend.Models.View.Display
{
    public class LegalProviderDisplayViewModel : Core.Web.API.Common.Models.Display.LegalProviderDisplayModel
    {
        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.LegalProvider entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}
