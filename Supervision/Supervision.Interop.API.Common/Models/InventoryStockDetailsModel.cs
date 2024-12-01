using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Supervision.Interop.API.Common.Models
{
    public class InventoryStockDetailsModel : InventoryStockOverviewModel
    {
        public List<WarehouseExistenseModel> Existences { get; set; }

        public decimal WeightedCost { get; set; }

        public decimal[] ReceptionsLastSemester { get; set; }
    }
}