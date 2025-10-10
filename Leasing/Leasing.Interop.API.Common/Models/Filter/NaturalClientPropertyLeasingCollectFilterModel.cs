namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Filter
{
    public class NaturalClientPropertyLeasingCollectFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.NaturalClientPropertyLeasingCollect, System.Guid>
    {
        public int Month { get; set; }

        public int Year { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.NaturalClientPropertyLeasingCollect, bool>> GetSelector()
        {
            return entity => !entity.Archived && entity.ExpectedAt.Month == Month && entity.ExpectedAt.Year == Year;
        }
    }
}
