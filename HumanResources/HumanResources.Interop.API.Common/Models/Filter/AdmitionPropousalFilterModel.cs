namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Filter
{
    public class AdmitionPropousalFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.AdmitionPropousal, System.Guid>
    {
        public System.Guid StaffId { get; set; }

        public System.Guid WorkPositionId { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.AdmitionPropousal, bool>> GetSelector()
        {
            return entity => entity.OcupationCandidate.Postulation.StaffId == StaffId && entity.OcupationCandidate.Postulation.Vacant.WorkPositionId == WorkPositionId;
        }
    }
}