using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract;

namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Filter
{
    public sealed class LegalClientVehicleLeasingControlActionFilterModel : IEntityFilterModel<LegalClientVehicleLeasingControlAction, System.Guid>
    {
        public System.Guid LeasingId { get; set; }

        public System.Linq.Expressions.Expression<System.Func<LegalClientVehicleLeasingControlAction, bool>> GetSelector() => entity => entity.LeasingId == LeasingId;
    }
}