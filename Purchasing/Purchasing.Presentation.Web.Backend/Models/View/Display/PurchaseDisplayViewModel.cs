using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Web.Backend.Models.View.Display
{
    public class PurchaseDisplayViewModel: Interop.API.Common.Models.Display.PurchaseDisplayModel
    {       

        public bool Archived { get; set; }

        public void Import(Persistence.Entities.Purchase entity)
        { 
            Archived = entity.Archived;
        }
    }
}
