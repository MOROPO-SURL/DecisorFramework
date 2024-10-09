namespace MOROPO.Framework.Decisor.Core.Presentation.Web.Backend.Models.View.Display
{
	public class LegalClientDisplayViewModel : Core.Web.API.Common.Models.Display.LegalClientDisplayModel
    {
        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.LegalClient entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}

