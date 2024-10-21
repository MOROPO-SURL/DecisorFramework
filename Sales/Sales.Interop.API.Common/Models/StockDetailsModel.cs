using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Sales.Interop.API.Common.Models
{
    public class StockDetailsModel : StockOverviewModel
    {
        public List<WarehouseExistenseModel> Existences { get; set; }

        public decimal WeightedCost { get; set; }

        public decimal[] ReceptionsLastSemester { get; set; }
    }
}