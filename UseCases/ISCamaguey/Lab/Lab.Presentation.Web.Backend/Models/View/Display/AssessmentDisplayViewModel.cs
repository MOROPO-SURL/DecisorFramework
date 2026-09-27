using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Web.Backend.Models.View.Display
{
    public class AssessmentDisplayViewModel : Interop.API.Common.Models.Display.
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.ProductionSample entity)
        {
            base.Import(entity);

            Enabled = entity.Enabled;
            Archived = entity.Archived;
        }
    }
}
