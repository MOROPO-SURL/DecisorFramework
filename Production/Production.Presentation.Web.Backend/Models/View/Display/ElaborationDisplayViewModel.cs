namespace MOROPO.Framework.Decisor.Production.Presentation.Web.Backend.Models.View.Display
{
    public class ElaborationDisplayViewModel : Interop.API.Common.Models.Display.ElaborationDisplayModel
    {
        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.Elaboration entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}

