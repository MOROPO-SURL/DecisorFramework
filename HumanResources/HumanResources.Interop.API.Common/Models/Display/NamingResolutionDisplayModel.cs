namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display
{
    public class NamingResolutionDisplayModel : Contract.AbstractIncorporationResolutionDisplayModel<Persistence.Entities.NamingResolution>
    {
        public OcupationCandidateDisplayModel Candidate { get; set; }

        public override void Import(Persistence.Entities.NamingResolution entity)
        {
            base.Import(entity);

            ConcretedAt = entity.ConcretedAt;

            if (entity.Candidate != null)
            {
                Candidate = new OcupationCandidateDisplayModel();

                Candidate.Import(entity.Candidate);
            }
        }
    }
}
