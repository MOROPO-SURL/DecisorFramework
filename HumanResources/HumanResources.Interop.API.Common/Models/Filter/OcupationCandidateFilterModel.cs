namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Filter
{
    public class OcupationCandidateFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.OcupationCandidate, System.Guid>
    {
        public Persistence.Enumerations.VacantOcupationMode VacantOcupationMode { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.OcupationCandidate, bool>> GetSelector()
        {
            return entity => entity.Postulation.Vacant.OcupationMode == VacantOcupationMode;
        }
    }
}
