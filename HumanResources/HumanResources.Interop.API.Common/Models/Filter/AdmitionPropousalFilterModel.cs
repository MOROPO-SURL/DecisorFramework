namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Filter
{
    public class AdmitionPropousalFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.AdmitionPropousal, System.Guid>
    {
        public System.Guid? StaffId { get; set; }

        public System.Guid? WorkPositionId { get; set; }

        public Persistence.Enumerations.VacantOcupationMode? OcupationMode { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.AdmitionPropousal, bool>> GetSelector()
        {
            if (StaffId != null && WorkPositionId != null)
                return entity => entity.OcupationCandidate.Postulation.StaffId == StaffId && entity.OcupationCandidate.Postulation.Vacant.WorkPositionId == WorkPositionId;

            if (OcupationMode != null)
                return entity => entity.OcupationCandidate.Postulation.Vacant.OcupationMode == OcupationMode;

            throw new System.InvalidOperationException();
        }
    }
}