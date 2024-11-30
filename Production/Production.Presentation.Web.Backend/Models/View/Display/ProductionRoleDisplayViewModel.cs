namespace MOROPO.Framework.Decisor.Production.Presentation.Web.Backend.Models.View.Display
{
    public class ProductionRoleDisplayViewModel : Interop.API.Common.Models.Display.ProductionRoleDisplayModel
    {
        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.ProductionRole entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}

