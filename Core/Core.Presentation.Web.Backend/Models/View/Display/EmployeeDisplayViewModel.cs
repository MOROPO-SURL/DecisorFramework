using MOROPO.Framework.Decisor.Core.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Core.Presentation.Web.Backend.Models.View.Display
{
	public class EmployeeDisplayViewModel : Core.Web.API.Common.Models.Display.EmployeeDisplayModel
    {
        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public override void Import(Employee entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}

