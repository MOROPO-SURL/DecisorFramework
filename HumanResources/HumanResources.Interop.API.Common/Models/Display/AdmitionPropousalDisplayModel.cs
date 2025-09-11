namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display
{
    public class AdmitionPropousalDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.AdmitionPropousal, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.DateTime At { get; set; }

        public OcupationCandidateDisplayModel Candidate { get; set; }

        public Governance.Interop.API.Common.Models.Display.AgreementDisplayModel Agreement { get; set; }

        public string Argument { get; set; }

        public void Import(Persistence.Entities.AdmitionPropousal entity)
        {
            Id = entity.Id;
            At = entity.At;
            Argument = entity.Argument;

            if (entity.OcupationCandidate != null)
            {
                Candidate = new OcupationCandidateDisplayModel();

                Candidate.Import(entity.OcupationCandidate);
            }

            if (entity.Agreement != null)
            {
                Agreement = new Governance.Interop.API.Common.Models.Display.AgreementDisplayModel();

                Agreement.Import(entity.Agreement);
            }
        }
    }
}
