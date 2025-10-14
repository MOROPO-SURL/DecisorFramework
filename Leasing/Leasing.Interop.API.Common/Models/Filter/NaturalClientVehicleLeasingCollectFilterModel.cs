namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Filter
{
    public class NaturalClientVehicleLeasingCollectFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.NaturalClientVehicleLeasingCollect, System.Guid>
    {
        public int Month { get; set; }

        public int Year { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.NaturalClientVehicleLeasingCollect, bool>> GetSelector()
        {
            return entity => !entity.Archived && entity.ExpectedAt.Month == Month && entity.ExpectedAt.Year == Year;
        }
    }
}
