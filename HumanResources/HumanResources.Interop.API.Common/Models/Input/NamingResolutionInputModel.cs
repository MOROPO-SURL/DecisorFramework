namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input
{
    public class NamingResolutionInputModel : Contract.AbstractIncorporationResolutionInputModel<Persistence.Entities.NamingResolution>
    {
        public System.Guid CandidateId { get; set; }

        public override void Mergue(Persistence.Entities.NamingResolution entity)
        {
            base.Mergue(entity);

            if (entity.CandidateId != CandidateId)
            {
                entity.Candidate = null;
                entity.CandidateId = CandidateId;
            }
        }
    }
}
