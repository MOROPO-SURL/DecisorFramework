namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Backend.Models.View.Display
{
    public class EmployeeDisplayViewModel : Interop.API.Common.Models.Display.EmployeeDisplayModel
    {
        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.Employee entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}

