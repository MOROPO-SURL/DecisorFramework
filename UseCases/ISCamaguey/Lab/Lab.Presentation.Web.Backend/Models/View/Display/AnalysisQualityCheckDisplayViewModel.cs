using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Web.Backend.Models.View.Display
{
    public class AnalysisQualityCheckDisplayViewModel : Interop.API.Common.Models.Display.AnalysisQualityCheckDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.AnalysisQualityCheck entity)
        {
            base.Import(entity);

            Archived = entity.Archived;
        }
    }
}
